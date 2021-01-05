using CurrencyConverter.BL.Interfaces;
using CurrencyConverter.BL.Interfaces.Domain;
using CurrencyConverter.BL.Interfaces.Logic;
using CurrencyConverter.BL.Interfaces.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.BL.Classes.Storage
{
    public class CurrencyRatesDictionary : ICurrencyRatesStorage
    {
        private IFormattedCurrencyReader _currencyProvider;
        private Dictionary<string, ICurrency> _dictionary;

        public CurrencyRatesDictionary(IFormattedCurrencyReader currencyProvider)
        {
            _currencyProvider = currencyProvider;

            if (_dictionary == null)
            {
                Update();
            }
        }

        public ICurrency GetCurrencyByCode(string currencyCode)
        {
            ICurrency currency;            

            if ( _dictionary.TryGetValue(currencyCode, out currency))
            {
                return currency;
            }

            throw new KeyNotFoundException();
        }

        public void Update()
        {
            if (_currencyProvider != null)
            {
                _dictionary.Clear();
                _dictionary = null;

                _dictionary = _currencyProvider.Read();
            }
        }


    }
}
