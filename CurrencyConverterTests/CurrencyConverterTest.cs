using System;
using Xunit;
using CurrencyConverter.BL.Interfaces.Logic;
using CurrencyConverter.BL.Classes.Logic;
using CurrencyConverter.BL.Classes.Domain;
using CurrencyConverter.BL.Interfaces.Domain;
using CurrencyConverter.BL.Interfaces.Storage;
using CurrencyConverter.BL.Classes.StorageInMemory;

namespace CurrencyConverterTests
{
    public class CurrencyConverterTest
    {
        [Fact]
        public void HundredRubToUSDConvertingTest()
        {
            //IDataProvider webDataProvider = new CommonWebFilesReader();
            //IFormattedCurrencyReader formattedDataProvider = new XMLCurrencyRatesReader(webDataProvider);
            //ICurrencyRatesStorage currencyRatesStorage = new CurrencyRatesRepository(formattedDataProvider);            
            //ICurrenciesFactory currenciesFactory = new CurrenciesFactory(currencyRatesStorage);
            //ICurrencyConverter currConverter = new CurrenciesConverter(currenciesFactory);

            //decimal resultAmountOfDollars = currConverter.Convert(CurrencyConverter.BL.Enums.ECurrencyCodes.RUB.ToString(), CurrencyConverter.BL.Enums.ECurrencyCodes.USD.ToString(), 100M);

            //Assert.Equal(1.3566M, decimal.Round(resultAmountOfDollars, 4));
           

            //ICurrency rubles = currenciesFactory.GetCurrency(CurrencyConverter.BL.Enums.ECurrencyCodes.RUB.ToString(), rubRate);
            //ICurrency dollars = currenciesFactory.GetCurrency(CurrencyConverter.BL.Enums.ECurrencyCodes.USD.ToString(), usdRate);

            //decimal resultAmountOfDollars = currConverter.Convert(rubles, dollars, 100M);

            //Assert.Equal(1.3566M, decimal.Round(resultAmountOfDollars, 4));
        }
    }
}
