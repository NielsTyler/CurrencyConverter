using CurrencyConverter.BL.Interfaces.Logic;
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
        ICurrencyConverter _currenciesConverter;
        ICurrenciesFactory _currenciesFactory;
        public CurrenciesController(ICurrencyConverter currenciesConverter) 
        {
            _currenciesConverter = currenciesConverter;
        }
                
        // GET api/currenciesRatesList
        //[HttpGet]
        //public IEnumerable<CurrencyRateViewModel> Get()
        //{
        //    List<CurrencyRateViewModel> currenciesInfo = new List<CurrencyRateViewModel>();

        //    //currenciesInfo.Add(
        //    //    new CurrencyRateViewModel() { Code = "USD", Name = "American Dollars", Rate = 123.23M });
        //    //currenciesInfo.Add(
        //    //    new CurrencyRateViewModel() { Code = "EUR", Name = "Euro", Rate = 1.33M });

        //    currenciesInfo.Add(
        //        new CurrencyRateViewModel() { title = "EURO", date = DateTime.Now, completed = false, amount = 10.23M  });
        //    currenciesInfo.Add(
        //        new CurrencyRateViewModel() { title = "DOLL", date = DateTime.Now, completed = true });

        //    return currenciesInfo;
        //}

        [HttpGet]
        [Route("api/YOURCONTROLLER/{currrencyCodeFrom}/{currencyCodeTarget}/{amount}")]
        public decimal Get(string currrencyCodeFrom, string currencyCodeTarget, decimal amount/*, DateTime dateFromHistory*/ )
        {
            List<CurrencyRateViewModel> currenciesInfo = new List<CurrencyRateViewModel>();
            //currenciesInfo.Add(
            //    new CurrencyRateViewModel() { Code = "USD", Name = "American Dollars", Rate = 123.23M });
            //currenciesInfo.Add(
            //    new CurrencyRateViewModel() { Code = "EUR", Name = "Euro", Rate = 1.33M });

            currenciesInfo.Add(
                new CurrencyRateViewModel() { title = "EURO", date = DateTime.Now, completed = false, amount = 10.23M });
            currenciesInfo.Add(
                new CurrencyRateViewModel() { title = "DOLL", date = DateTime.Now, completed = true });

            return amount;
        }
    }
}
