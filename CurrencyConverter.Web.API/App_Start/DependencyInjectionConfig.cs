using CurrencyConverter.BL.Classes.Logic;
using CurrencyConverter.BL.Classes.StorageInMemory;
using CurrencyConverter.BL.Interfaces.Logic;
using CurrencyConverter.BL.Interfaces.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Web.API.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void AddScope(IServiceCollection services)
        {
            services.AddScoped<IDataProvider, CommonWebFilesReader>();
            services.AddScoped<ICurrenciesFactory, CurrenciesFactory>();
            services.AddScoped<IFormattedCurrencyReader, XMLCurrencyRatesReader>();
            services.AddScoped<ICurrencyRatesStorage, CurrencyRatesRepository>();
            services.AddScoped<ICurrencyConverter, CurrenciesConverter>();
        }
    }
}
