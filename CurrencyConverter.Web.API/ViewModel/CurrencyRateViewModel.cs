using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Web.API.ViewModel
{
    public class CurrencyInfoViewModel
    {
        public CurrencyInfoViewModel() { }
        public String code { get; set; }
        public String title { get; set; }
        public Decimal rate { get; set; }
    }
}
