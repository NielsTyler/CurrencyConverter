using CurrencyConverter.BL.Enums;
using CurrencyConverter.BL.Classes.Domain;
using CurrencyConverter.BL.Interfaces.Logic;
using CurrencyConverter.BL.Interfaces.Domain;
using System;
using System.Globalization;
using CurrencyConverter.BL.Interfaces.Storage;
using System.Collections.Generic;

namespace CurrencyConverter.BL.Classes.Logic { 
    public class CurrenciesFactory : ICurrenciesFactory
    {
        ICurrencyRatesStorage _exchangeRatesStorage;
        public CurrenciesFactory(ICurrencyRatesStorage exchangeRatesStorage)
        {
            _exchangeRatesStorage = exchangeRatesStorage;
        }

        public ICurrency GetCurrency(string code)
        {
            return new CurrencyInfo() { Code = (ECurrencyCodes)Enum.Parse(typeof(ECurrencyCodes), code),
                                        Rate = _exchangeRatesStorage.GetRate(code), 
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

        public IEnumerable<ICurrency> GetAllCurrenciesList()
        {
            var codes = _exchangeRatesStorage.GetAvilableCurrenciesCodes();
            var currenciesList = new List<ICurrency>();

            foreach (var code in codes)
            {
                currenciesList.Add(GetCurrency(code));
            }

            return currenciesList;
        }
    }
}
