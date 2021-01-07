using System.Collections.Generic;

namespace CurrencyConverter.BL.Interfaces.Storage
{
    public interface ICurrencyRatesStorage
    {
        decimal GetRate(string currencyCode);

        void Add(string currencyCode, decimal currencyRate);

        void Update();

        void Clear();
        IEnumerable<string> GetAvilableCurrenciesCodes();
    }
}
