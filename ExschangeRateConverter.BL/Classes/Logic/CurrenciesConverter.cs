using CurrencyConverter.BL.Enums;
using CurrencyConverter.BL.Interfaces.Domain;
using CurrencyConverter.BL.Interfaces.Logic;
using CurrencyConverter.BL.Interfaces.Storage;
using System;

namespace CurrencyConverter.BL.Classes.Logic
{
    public class CurrenciesConverter : ICurrencyConverter
    {
        //private ICurrency _baseCurrency;
        private ICurrencyRatesStorage _storage;

        public CurrenciesConverter()
        {
        }

        public decimal Convert(ICurrency currencyFrom, ICurrency currencyTo, decimal Amount)
        {
            return ConvertToBaseCurrency(currencyFrom, Amount) * currencyTo.Rate;
        }

        private decimal ConvertToBaseCurrency(ICurrency currencyFrom, decimal Amount)
        {
            return Amount / currencyFrom.Rate;
        }
    }
}
