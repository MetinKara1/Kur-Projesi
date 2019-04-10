using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurExample.DataRead
{
    public class XmlRead
    {
        public List<Currency> Read()
        {
            var currencyList = new List<Currency>();
            try
            {
                string xmlLink = "https://www.tcmb.gov.tr/kurlar/today.xml";
                var ds = new DataSet();
                ds.ReadXml(xmlLink);
                
                foreach (DataRow item in ds.Tables[1].Rows)
                {
                    currencyList.Add(new Currency
                    {
                        CurrencyCode = item["CurrencyCode"].ToString(),
                        Unit = Convert.ToInt32(item["Unit"].ToString()),
                        CurrencyType = item["Isim"].ToString(),
                        ForexBuying = Convert.ToDecimal(item["ForexBuying"].ToString()),
                        ForexSelling = Convert.ToDecimal(item["ForexSelling"].ToString()),
                        Deleted = false,
                        UpdateDate = DateTime.Now,
                        ChangeDate = DateTime.Now
                    });
                };
            }
            catch (Exception ex)
            {

            }
            return currencyList;
        }
    }
}
