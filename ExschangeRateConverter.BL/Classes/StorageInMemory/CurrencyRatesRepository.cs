using CurrencyConverter.BL.Interfaces.Logic;
using CurrencyConverter.BL.Interfaces.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.BL.Classes.StorageInMemory
{
    public class CurrencyRatesRepository : ICurrencyRatesStorage
    {
        private Dictionary<string, decimal> _dictionary = new Dictionary<string, decimal>();
        IFormattedCurrencyReader _dataProvider;

        public CurrencyRatesRepository(IFormattedCurrencyReader dataProvider)
        {
            _dataProvider = dataProvider;

            _dataProvider.Update(_dictionary);
        }
        public void Add(string currencyCode, decimal currencyRate)
        {
            _dictionary.Add(currencyCode, currencyRate);
        }

        public void Update()
        {
            Clear();
            _dataProvider.Update(_dictionary);
        }

        public decimal GetRate(string currencyCode)
        {
            decimal rate;

            if (_dictionary.TryGetValue(currencyCode, out rate))
            {
                return rate;
            }

            throw new KeyNotFoundException();
        }

        public void Clear()
        {
            _dictionary.Clear();
        }

    }
}
