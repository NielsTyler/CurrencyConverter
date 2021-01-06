using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Web.API.ViewModel
{
    public class CurrencyRateViewModel
    {
        public CurrencyRateViewModel() { }
        //public String Code { get; set; }
        //public String Name { get; set; }
        //public Decimal Rate { get; set; }

        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
        public DateTime date { get; set; }
        public Decimal amount { get; set; }
    }
}
