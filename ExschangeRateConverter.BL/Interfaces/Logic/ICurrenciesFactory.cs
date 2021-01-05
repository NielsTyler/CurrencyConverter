using CurrencyConverter.BL.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.BL.Interfaces.Logic
{
    public interface ICurrenciesFactory
    {
        ICurrency GetCurrency(string code, decimal rate);
    }
}
