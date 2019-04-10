using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataBaseFolder
{
    public class CurrencyRate
    {
        public int Id { get; set; }
        public Currency CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public int Unit { get; set; }
        public string FirstCurrency { get; set; }
        public decimal CrossRate { get; set; }
        public string SecondCurrency { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
