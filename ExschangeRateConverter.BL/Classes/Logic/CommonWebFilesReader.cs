using CurrencyConverter.BL.Interfaces.Logic;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.BL.Classes.Logic
{
    public class CommonWebFilesReader: IDataProvider
    {
        //private ILinkSearcher _pathFinder; //SearchForAppropriateLink() and etc
        private const string DEFAULT_EXCHANGE_RATES_SOURCE = @"https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml?5e8b3df927838787a7aad713e2d4c372";
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
