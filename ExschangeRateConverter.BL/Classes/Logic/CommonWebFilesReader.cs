using CurrencyConverter.BL.Interfaces.Logic;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.BL.Classes.Logic
{
    public class CommonWebFilesReader: IDataProvider
    {
        private readonly IConfiguration Configuration;
        //private ILinkSearcher _pathFinder; //SearchForAppropriateLink() and etc
        private readonly string DEFAULT_EXCHANGE_RATES_SOURCE;

        public CommonWebFilesReader(IConfiguration configuration)
        {
            Configuration = configuration;

            DEFAULT_EXCHANGE_RATES_SOURCE = Configuration["UrlCurrenciesInfoSource"];
        }
        public async Task<string> ReadWebFileAsync(string url = null)
        {
            url ??= DEFAULT_EXCHANGE_RATES_SOURCE;

            using (var client = new HttpClient())
            {
                using (var result = await client.GetAsync(url))
                {
                    if (result.IsSuccessStatusCode)
                    {
                        return await result.Content.ReadAsStringAsync();
                    }

                }
            }
            return null;
        }       
    }
}
