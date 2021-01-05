using CurrencyConverter.Web.API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Web.API.Controllers
{
    [Route("api/[controller]")]
    public class CurrenciesController : Controller
    {
        public CurrenciesController()
        { }
        //IUserMap userMap;
        //public UserController(IUserMap map)
        //{
        //    userMap = map;
        //}

        // GET api/currenciesRatesList
        [HttpGet]
        public IEnumerable<CurrencyRateViewModel> Get()
        {
            List<CurrencyRateViewModel> currenciesInfo = new List<CurrencyRateViewModel>();

            currenciesInfo.Add(
                new CurrencyRateViewModel() { Code = "USD", Name = "American Dollars", Rate = 123.23M });
            currenciesInfo.Add(
                new CurrencyRateViewModel() { Code = "EUR", Name = "Euro", Rate = 1.33M });
            
            return currenciesInfo;
        }
    }
}
