using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Currency
    {
        public int Id { get; set; }
        public string CurrencyCode { get; set; }
        public int Unit { get; set; }
        public string CurrencyType { get; set; }
        public decimal ForexBuying { get; set; }
        public decimal ForexSelling { get; set; }
        public bool Deleted { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
