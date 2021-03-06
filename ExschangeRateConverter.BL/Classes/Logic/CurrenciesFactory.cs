﻿using CurrencyConverter.BL.Enums;
using CurrencyConverter.BL.Classes.Domain;
using CurrencyConverter.BL.Interfaces.Logic;
using CurrencyConverter.BL.Interfaces.Domain;
using System;
using System.Globalization;

namespace CurrencyConverter.BL.Classes.Logic { 
    public class CurrenciesFactory : ICurrenciesFactory
    {
        public ICurrency GetCurrency(string code, decimal rate)
        {
            return new CurrencyInfo() { Code = (ECurrencyCodes)Enum.Parse(typeof(ECurrencyCodes), code),
                                        Rate = rate, 
                                        Name = GetCurrencyFullName(code) };
        }

        private String GetCurrencyFullName(string code)
        {
            var cultureInfo = CultureInfoFromCurrencyISO(code);
            //var NumberFormat = cultureInfo.NumberFormat;
            var region = new RegionInfo(cultureInfo.LCID);
            //string Symbol = region.CurrencySymbol;
            string EnglishName = region.CurrencyEnglishName;

            return EnglishName;
        }

        private CultureInfo CultureInfoFromCurrencyISO(string isoCode)
        {
            //CultureInfo cultureInfo = (from culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures)
            //  let region = new RegionInfo(culture.LCID)
            //  where String.Equals(region.ISOCurrencySymbol, isoCode, StringComparison.InvariantCultureIgnoreCase)
            //  select culture).First();
            //return cultureInfo;
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo ri = new RegionInfo(ci.LCID);
                if (ri.ISOCurrencySymbol == isoCode)
                    return ci;
            }
            throw new Exception("Currency code " + isoCode + " is not supported by the current .Net Framework.");
        }
    }
}
