using BusinessLayer.Interfaces;
using CommonLayer;
using Newtonsoft.Json;
using YahooFinanceApi;
using static System.Net.WebRequestMethods;

namespace BusinessLayer
{
    public class CollectData : ICollectData
    {
        public async Task<List<DisplayDataModel>> GetData(string symbols, DateTime dateTime)
        {
            List<DisplayDataModel> result = new List<DisplayDataModel>();

            var allSymbols = symbols.Split(',');

            foreach (var symbol in allSymbols) 
            {
                DisplayDataModel data = new DisplayDataModel();

                data.date = dateTime.ToString("dd.MM.yyyy.");

                var securities = await Yahoo.Symbols(symbol).QueryAsync();

                var fields = securities[symbol].Fields;
                data.fullCompanyName = fields["LongName"];
                data.marcetCap = fields["MarketCap"].ToString("C");

                var profile = await GetAssetProfileAsync(symbol);

                data.numberOfEmployees = profile.body.fullTimeEmployees;
                data.headquartersCity = profile.body.city;
                data.headquartersCountry = profile.body.country;


                var history = await Yahoo.GetHistoricalAsync(symbol, dateTime, dateTime.AddDays(1), Period.Daily);

                if (history.Count > 0)
                {
                    data.closePrice = history[0].Close.ToString();
                    data.openPrice = history[0].Open.ToString();
                }
                result.Add(data);
            }

            return result;
        }

        private async Task<AssetProfileModel> GetAssetProfileAsync(string symbol)
        {
            string uri = "https://yahoo-finance15.p.rapidapi.com/api/v1/markets/stock/modules?ticker="+symbol+"&module=asset-profile";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri),
                Headers =
                {
                    { "X-RapidAPI-Key", "7abe6aa6aamsh4b519235bbcb971p138580jsnbd6c1ec9d677" },
                    { "X-RapidAPI-Host", "yahoo-finance15.p.rapidapi.com" },
                },
            };

            AssetProfileModel root = new AssetProfileModel();

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();

                root = JsonConvert.DeserializeObject<AssetProfileModel>(jsonString);

            }

            return root;
        }
    }
}