﻿using CurrencyConverter.BL.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.BL.Interfaces.Logic
{
    public interface IFormattedCurrencyReader
    {
        void Update(Dictionary<string, decimal> dictionary);
    }
}
