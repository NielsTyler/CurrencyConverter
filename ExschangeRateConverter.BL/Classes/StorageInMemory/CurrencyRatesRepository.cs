using CurrencyConverter.BL.Interfaces.Logic;
using CurrencyConverter.BL.Interfaces.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.BL.Classes.StorageInMemory
{
    public class CurrencyRatesRepository : ICurrencyRatesStorage
    {
        private Dictionary<string, decimal> _dictionary = new Dictionary<string, decimal>();
        private readonly IConfiguration Configuration;
        private IFormattedCurrencyReader _dataProvider;

        public CurrencyRatesRepository(IConfiguration configuration, IFormattedCurrencyReader dataProvider)
        {
            Configuration = configuration;
            _dataProvider = dataProvider;

            Update();
        }
        public void Add(string currencyCode, decimal currencyRate)
        {            
            _dictionary.Add(currencyCode, currencyRate);
        }

        public void Update()
        {
            Clear();

            var basicCurrencyCode = Configuration["BasicCurrencyCode"];
            _dictionary.Add(basicCurrencyCode, 1);
            _dataProvider.Update(this);
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

        public IEnumerable<string> GetAvilableCurrenciesCodes()
        {
            if (_dictionary != null)
            {
                return _dictionary.Keys;
            }
            else
                return new List<string>();
        }
    }
}
