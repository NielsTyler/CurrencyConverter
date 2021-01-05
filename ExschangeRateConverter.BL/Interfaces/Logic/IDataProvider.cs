using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.BL.Interfaces.Logic
{
    public interface IDataProvider
    {
        Task<string> ReadWebFileAsync(string url = null);
    }
}
