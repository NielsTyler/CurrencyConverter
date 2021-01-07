using System;
using System.Globalization;
using CurrencyConverter.BL.Classes.Logic;
using CurrencyConverter.BL.Classes.StorageInMemory;
using CurrencyConverter.BL.Interfaces;
using CurrencyConverter.BL.Interfaces.Logic;
using CurrencyConverter.BL.Interfaces.Storage;

namespace CurrencyConverterBaseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //IDataProvider dataProvider = new CommonWebFilesReader();
            //IDataProvider webDataProvider = new CommonWebFilesReader();
            //IFormattedCurrencyReader formattedDataProvider = new XMLCurrencyRatesReader(webDataProvider);
            //ICurrencyRatesStorage currencyRatesStorage = new CurrencyRatesRepository(formattedDataProvider);
            //ICurrenciesFactory currenciesFactory = new CurrenciesFactory(currencyRatesStorage);
            //ICurrencyConverter currConverter = new CurrenciesConverter(currenciesFactory);           

            //Console.WriteLine(ratesDataXML.Length);
            Console.ReadKey();
        }        	
}
}
