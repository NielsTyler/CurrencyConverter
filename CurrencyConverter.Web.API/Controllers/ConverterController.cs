using CurrencyConverter.BL.Interfaces.Logic;
using CurrencyConverter.Web.API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Web.API.Controllers
{
    public class ConverterController : Controller
    {
        ICurrencyConverter _currenciesConverter;
        public ConverterController(ICurrencyConverter currenciesConverter) 
        {
            _currenciesConverter = currenciesConverter;
        }

        [Route("currenciesList")]
        public IEnumerable<CurrencyInfoViewModel> GetAll() => _currenciesConverter.GetCurrenciesInfo().Select(c => new CurrencyInfoViewModel()
        {
            code = c.Code.ToString(),
            title = c.Name,
            rate = c.Rate
        });

        [Route("convert/{currrencyCodeFrom}/{currencyCodeTarget}/{amount:int}/{dateFromHistory?}")]
        public decimal Convert(string currrencyCodeFrom, string currencyCodeTarget, decimal amount, DateTime? dateFromHistory = null)
        {
            if (!dateFromHistory.HasValue)
                dateFromHistory = DateTime.Now;

            if (String.IsNullOrEmpty(currrencyCodeFrom) || String.IsNullOrEmpty(currencyCodeTarget) || amount == 0)
            {
                throw new ArgumentException(
                    $"Currency and amount parameters cannot be empty or 0.");
            }

            if (_currenciesConverter == null)
            {
                throw new NullReferenceException("Currency converter cannot be null.");
            }

            //TODO: Implement IsCurrencyAvailable
            //if (!_currenciesConverter.IsCurrencyAvailable(currrencyCodeFrom) || !_currenciesConverter.IsCurrencyAvailable(currencyCodeTarget))
            //{
            //    throw new CCException("Such currency is not available.");
            //}

            return _currenciesConverter.Convert(currrencyCodeFrom, currencyCodeTarget, amount);
        }
    }
}
