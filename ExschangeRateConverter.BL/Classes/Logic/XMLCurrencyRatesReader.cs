
using CurrencyConverter.BL.Interfaces.Logic;
using CurrencyConverter.BL.Interfaces.Storage;
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
        private IDataProvider _xmlDataProvider;
        private const string CURRENCY_NODE = "Cube";
        private const string CODE_ATTR = "currency";
        private const string RATE_ATTR = "rate";

        public XMLCurrencyRatesReader(IDataProvider xmlDataProvider)
        {
            _xmlDataProvider = xmlDataProvider;     
        }

        public void Update(ICurrencyRatesStorage repository)
        {
            var xmlData = _xmlDataProvider.ReadWebFileAsync().Result;

            SetUpDictionaryFromXML(repository, xmlData);
        }

        private void SetUpDictionaryFromXML(ICurrencyRatesStorage repository, string xmlData)
        {
            XDocument doc = XDocument.Parse(xmlData);
            var currencyRatesElements = doc.Descendants().Where(p => p.Name.LocalName == CURRENCY_NODE && p.Attribute(CODE_ATTR) != null && p.Attribute(RATE_ATTR) != null);

            if (currencyRatesElements != null && currencyRatesElements.Count() > 0)
            {
                try
                {                    
                    foreach (var cNode in currencyRatesElements)
                    {
                        string code = cNode.Attribute(CODE_ATTR).Value;

                        repository.Add(code, decimal.Parse(cNode.Attribute(RATE_ATTR).Value));
                    }
                }
                catch (Exception ex)
                {
                    //Logger.
                    throw ex;
                }                
            }    
        }
    }
}
