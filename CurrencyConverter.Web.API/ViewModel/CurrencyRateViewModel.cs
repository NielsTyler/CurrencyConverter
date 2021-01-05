using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Web.API.ViewModel
{
    public class CurrencyRateViewModel
    {
        public CurrencyRateViewModel() { }
        public String Code { get; set; }
        public String Name { get; set; }
        public Decimal Rate { get; set; }
    }
}
