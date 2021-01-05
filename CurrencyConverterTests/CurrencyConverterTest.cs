using System;
using Xunit;
using CurrencyConverter.BL.Interfaces.Logic;
using CurrencyConverter.BL.Classes.Logic;
using CurrencyConverter.BL.Classes.Domain;
using CurrencyConverter.BL.Interfaces.Domain;

namespace CurrencyConverterTests
{
    public class CurrencyConverterTest
    {
        [Fact]
        public void HundredRubToUSDConvertingTest()
        {
            ICurrencyConverter currConverter = new CurrenciesConverter();
            ICurrenciesFactory currenciesFactory = new CurrenciesFactory();

            decimal rubRate = 90.0681M;
            decimal usdRate = 1.2219M;

            ICurrency rubles = currenciesFactory.GetCurrency(CurrencyConverter.BL.Enums.ECurrencyCodes.RUB.ToString(), rubRate);
            ICurrency dollars = currenciesFactory.GetCurrency(CurrencyConverter.BL.Enums.ECurrencyCodes.USD.ToString(), usdRate);

            decimal resultAmountOfDollars = currConverter.Convert(rubles, dollars, 100M);

            Assert.Equal(1.3566M, decimal.Round(resultAmountOfDollars, 4));
        }
    }
}
