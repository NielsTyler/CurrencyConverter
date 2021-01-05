using System;
using System.Globalization;
using CurrencyConverter.BL.Classes.Logic;
using CurrencyConverter.BL.Classes.Storage;
using CurrencyConverter.BL.Interfaces;
using CurrencyConverter.BL.Interfaces.Logic;
using CurrencyConverter.BL.Interfaces.Storage;

namespace CurrencyConverterBaseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IDataProvider dataProvider = new CommonWebFilesReader();
            ICurrenciesFactory currencyFactory = new CurrenciesFactory();
            IFormattedCurrencyReader XMLReader = new XMLCurrencyRatesReader(currencyFactory, dataProvider);
            ICurrencyRatesStorage storage = new CurrencyRatesDictionary(XMLReader);
            ICurrencyConverter currConverter = new CurrenciesConverter();

            var curr = storage.GetCurrencyByCode("USD");

            Console.WriteLine($"Currency: {curr.Name}  Rate: {curr.Rate}");
            //var dict = r.RetrieveActualDataAsync(null).Result;

            //foreach (var d in dict)
            //{
            //    Console.WriteLine($"Code: {d.Key} and currency name: {GetCurrName(d.Key)}");//Enum.GetName(typeof(CurrencyCodes), d.Key))}
            //}
            //string ratesDataXML  = CommonWebFilesReader.ReadFileAsync().Result;
            //XDocument doc = XDocument.Parse(ratesDataXML);

            //Console.WriteLine(ratesDataXML.Length);
            Console.ReadKey();
        }        	
}
}
