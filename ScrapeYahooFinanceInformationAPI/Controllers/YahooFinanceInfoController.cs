using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ScrapeYahooFinanceInformationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YahooFinanceInfoController : ControllerBase
    {
        [HttpGet]
        public string Get(string tickers, DateTime dateTime)
        {
            return "Slobodan";
        }
    }
}
