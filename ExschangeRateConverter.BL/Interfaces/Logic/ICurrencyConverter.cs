using CurrencyConverter.BL.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.BL.Interfaces.Logic
{
    public interface ICurrencyConverter
    {
        decimal Convert(ICurrency currencyFrom, ICurrency currencyTo, decimal Amount);
    }
}
