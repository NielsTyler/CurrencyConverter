using CurrencyConverter.BL.Classes.Domain;
using CurrencyConverter.BL.Enums;
using CurrencyConverter.BL.Interfaces.Domain;
using CurrencyConverter.BL.Interfaces.Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CurrencyConverter.BL.Classes.Logic
{
    public class XMLCurrencyRatesReader: IFormattedCurrencyReader
    {
        private ICurrenciesFactory _currenciesFactory;
        private IDataProvider _stringDataProvider;
        private const string CURRENCY_NODE = "Cube";
        private const string CODE_ATTR = "currency";
        private const string RATE_ATTR = "rate";

        public XMLCurrencyRatesReader(ICurrenciesFactory currenciesFactory, IDataProvider stringDataProvider)
        {
            _currenciesFactory = currenciesFactory;
            _stringDataProvider = stringDataProvider;
        }

        public Dictionary<string, ICurrency> Read()
        {
            var xmlData = _stringDataProvider.ReadWebFileAsync().Result;

            return SetUpDictionaryFromXML(xmlData);
        }

        public Dictionary<string, ICurrency> SetUpDictionaryFromXML(string xmlData)
        {
            XDocument doc = XDocument.Parse(xmlData);
            var currencyRatesElements = doc.Descendants().Where(p => p.Name.LocalName == CURRENCY_NODE && p.Attribute(CODE_ATTR) != null && p.Attribute(RATE_ATTR) != null);

            if (currencyRatesElements != null && currencyRatesElements.Count() > 0)
            {
                try
                {
                    Dictionary<string, ICurrency> resultDict = new Dictionary<string, ICurrency>();

                    foreach (var cNode in currencyRatesElements)
                    {
                        string code = cNode.Attribute(CODE_ATTR).Value;

                        resultDict.Add(code, _currenciesFactory.GetCurrency(code, decimal.Parse(cNode.Attribute(RATE_ATTR).Value)));
                    }

                    return resultDict;
                }
                catch (Exception ex)
                {
                    //Logger.
                    throw ex;
                }                
            }

            return new Dictionary<string, ICurrency>();           
        }
    }
}
