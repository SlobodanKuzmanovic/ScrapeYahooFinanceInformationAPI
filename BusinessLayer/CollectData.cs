using BusinessLayer.Interfaces;
using CommonLayer;
using Newtonsoft.Json;
using System;
using YahooFinanceApi;
using static System.Net.WebRequestMethods;

namespace BusinessLayer
{
    public class CollectData : ICollectData
    {
        public ISaveData _saveData { get; set; }

        public CollectData(ISaveData saveData)
        {
            _saveData = saveData;
        }

        public async Task<ViewModel> GetData(string symbols, DateTime dateTime)
        {
            ViewModel result = new ViewModel();

            var allSymbols = symbols.Replace(" ", "").ToUpper().Split(',');

            foreach (var symbol in allSymbols) 
            {
                var securities = await Yahoo.Symbols(symbol).QueryAsync();
                if (securities.Count == 0)
                {
                    result.badData.Add(symbol);
                    continue;
                }

                DatabaseDataModel data = new DatabaseDataModel();
                data.Symbol = symbol;
                data.date = dateTime;
                
                var fields = securities[symbol].Fields;

                data.fullCompanyName = fields["LongName"];
                data.marcetCap = fields["MarketCap"];

                var profile = await GetAssetProfileAsync(symbol);

                data.numberOfEmployees = profile.body.fullTimeEmployees;
                data.headquartersCity = profile.body.city;
                data.headquartersCountry = profile.body.country;

                var history = await Yahoo.GetHistoricalAsync(symbol, dateTime, dateTime.AddDays(1), Period.Daily);

                if (history.Count > 0)
                {
                    data.closePrice = history[0].Close;
                    data.openPrice = history[0].Close;
                }
                _saveData.Save(data);
                result.data.Add(new CorrectData(symbol, PrepareData(data)));
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

        private DisplayDataModel PrepareData(DatabaseDataModel databaseData)
        {
            DisplayDataModel data = new DisplayDataModel()
            {
                fullCompanyName = databaseData.fullCompanyName,
                marcetCap = databaseData.marcetCap.ToString("C"),
                yearFounded = databaseData.yearFounded == null ? "//" : databaseData.yearFounded.ToString(),
                numberOfEmployees = databaseData.numberOfEmployees,
                headquartersCity = databaseData.headquartersCity,
                headquartersCountry = databaseData.headquartersCountry,
                date = databaseData.date.ToString("dd.MM.yyyy."),
                closePrice = databaseData.closePrice.ToString("C"),
                openPrice = databaseData.openPrice.ToString("C")
            };

            return data;
        }
    }
}