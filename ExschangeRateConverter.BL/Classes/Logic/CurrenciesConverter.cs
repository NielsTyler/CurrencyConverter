using CurrencyConverter.BL.Enums;
using CurrencyConverter.BL.Interfaces.Domain;
using CurrencyConverter.BL.Interfaces.Logic;
using CurrencyConverter.BL.Interfaces.Storage;
using System;
using System.Collections.Generic;

namespace CurrencyConverter.BL.Classes.Logic
{
    public class CurrenciesConverter : ICurrencyConverter
    {
        ICurrenciesFactory _currenciesFactory;

        public CurrenciesConverter(ICurrenciesFactory factory)
        {
            _currenciesFactory = factory;
        }

        public decimal Convert(string currencyCodeFrom, string currencyCodeTo, decimal amount)
        {
            ICurrency currencyFrom = _currenciesFactory.GetCurrency(currencyCodeFrom);
            ICurrency resultCurrency = _currenciesFactory.GetCurrency(currencyCodeTo);

            return Convert(currencyFrom, resultCurrency, amount);
        }

        public IEnumerable<ICurrency> GetCurrenciesInfo()
        {
            return _currenciesFactory.GetAllCurrenciesList();
        }

        private decimal Convert(ICurrency currencyFrom, ICurrency currencyTo, decimal Amount)
        {
            return ConvertToBaseCurrency(currencyFrom, Amount) * currencyTo.Rate;
        }

        private decimal ConvertToBaseCurrency(ICurrency currencyFrom, decimal Amount)
        {
            return Amount / currencyFrom.Rate;
        }
    }
}
