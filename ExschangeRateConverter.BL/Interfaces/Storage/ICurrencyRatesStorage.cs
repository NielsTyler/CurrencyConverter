using CurrencyConverter.BL.Interfaces.Domain;

namespace CurrencyConverter.BL.Interfaces.Storage
{
    public interface ICurrencyRatesStorage
    {
        void Update();

        ICurrency GetCurrencyByCode(string currencyCode);
    }
}
