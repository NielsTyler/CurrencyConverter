using CurrencyConverter.BL.Enums;
using CurrencyConverter.BL.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.BL.Classes.Domain
{
    public class CurrencyInfo : ICurrency
    {
        public CurrencyInfo() { }
        public ECurrencyCodes Code { get; set; }
        public String Name { get; set; }
        public Decimal Rate { get; set; }
    }
}
