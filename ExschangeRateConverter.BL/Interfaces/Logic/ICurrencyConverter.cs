using CurrencyConverter.BL.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.BL.Interfaces.Logic
{
    public interface ICurrencyConverter
    {
        decimal Convert(string currencyCodeFrom, string currencyCodeTo, decimal Amount);
        IEnumerable<ICurrency> GetCurrenciesInfo();
    }
}
