using CurrencyConverter.BL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.BL.Interfaces.Domain
{
    public interface ICurrency
    {
        ECurrencyCodes Code { get; set; }
        string Name { get; set; }
        decimal Rate { get; set; }
    }
}
