using BusinessLayer.Interfaces;
using CommonLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ScrapeYahooFinanceInformationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YahooFinanceInfoController : ControllerBase
    {
        ICollectData _collectData;
        public YahooFinanceInfoController(ICollectData collectData)
        { 
            _collectData = collectData;
        }

        [HttpGet]
        public async Task<ViewModel> Get(string tickers, DateTime dateTime)
        {
            return await _collectData.GetData(tickers, dateTime);
        }
    }
}
