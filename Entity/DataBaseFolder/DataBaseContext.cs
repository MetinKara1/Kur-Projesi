using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Entity.DataBaseFolder
{
    public class DataBaseContext
    {
        private IDbConnection connectionProperty = null; // her metod bu parametre ile veritabanına bağlanacak. 
        public IDbConnection DbConnection(IDbConnection con)
        {
            string connection = "Server = DESKTOP-L6VOVGM; Database = CurDataBase; User ID = sa;Password=1;Trusted_Connection=False";
            var conn = new SqlConnection(connection);
            conn.Open();
            return conn;
        }

        public List<Currency> SelectCurrency()
        {
            this.connectionProperty = DbConnection(connectionProperty);
            var currencyList = connectionProperty.Query<Currency>("SELECT * FROM Currency").ToList();
            connectionProperty.Close();
            return currencyList;
        }
        public List<CurrencyRate> SelectCurrencyRate()
        {
            this.connectionProperty = DbConnection(connectionProperty);
            var currencyRateList = connectionProperty.Query<CurrencyRate>("SELECT * FROM CurrencyRate").ToList();
            connectionProperty.Close();
            return currencyRateList;
        }


        public void InsertCurrency(List<Currency> currencyList)
        {
            this.connectionProperty = DbConnection(connectionProperty);
            string sql = @"INSERT INTO Currency(
                CurrencyCode,
                Unit,
                CurrencyType,
                ForexBuying,
                ForexSelling,
                Deleted,
                UpdateDate,
                ChangeDate)
                VALUES(
                @CurrencyCode,
                @Unit,
                @CurrencyType,
                @ForexBuying,
                @ForexSelling,
                @Deleted,
                @UpdateDate,
                @ChangeDate)";

            foreach (var item in currencyList)
            {
                var insertData = connectionProperty.Execute(sql, new Currency
                {
                    CurrencyCode = item.CurrencyCode,
                    Unit = item.Unit,
                    CurrencyType = item.CurrencyType,
                    ForexBuying = item.ForexBuying,
                    ForexSelling = item.ForexSelling,
                    Deleted = item.Deleted,
                    UpdateDate = item.UpdateDate,
                    ChangeDate = item.ChangeDate
                });
            }
            this.connectionProperty.Close();

        }
        public void InsertCurrencyRate(List<CurrencyRate> currenyRateList)
        {
            this.connectionProperty = DbConnection(connectionProperty);

            string sql = @"INSERT INTO CurrencyRate(
                            CurrencyCode,
                            Unit,
                            FirstCurrency,
                            CrossRate,
                            SecondCurrency,
                            UpdateDate)
                            VALUES(
                            @CurrencyCode,
                            @Unit,
                            @FirstCurrency,
                            @CrossRate,
                            @SecondCurrency,
                            @UpdateDate)";

            foreach (var item in currenyRateList)
            {
                var InsertData = connectionProperty.Execute(sql, new CurrencyRate
                {
                    CurrencyCode = item.CurrencyCode,
                    Unit = item.Unit,
                    FirstCurrency = item.FirstCurrency,
                    CrossRate = item.CrossRate,
                    SecondCurrency = item.SecondCurrency,
                    UpdateDate = item.UpdateDate
                });
            }
            this.connectionProperty.Close();
        }

        public void UpdateCurrency(List<Currency> listCurrency)
        {
            this.connectionProperty = DbConnection(connectionProperty);
            var lastCurrenyList = SelectCurrency(); // gelen verideki satırlar birbirine uyuşmazsa currencycodea göre bul ve update et.
            if (lastCurrenyList.Count > 0)
            {
                string sql = @"UPDATE Currency SET CurrencyCode = @CurrencyCode, CurrencyType = @CurrencyType, Unit = @Unit, ForexBuying = @ForexBuying, ForexSelling = @ForexSelling, Deleted = @Deleted, UpdateDate = @UpdateDate, ChangeDate = @ChangeDate";
                foreach (var item in listCurrency)
                {
                    var currencyModel = lastCurrenyList.Where(x => x.CurrencyCode == item.CurrencyCode).First();
                    if (!string.IsNullOrWhiteSpace(currencyModel.CurrencyCode))
                    {
                        var UpdateData = connectionProperty.Execute(sql, new Currency
                        {
                            CurrencyCode = currencyModel.CurrencyCode,
                            Unit = currencyModel.Unit,
                            CurrencyType = currencyModel.CurrencyType,
                            ForexBuying = currencyModel.ForexBuying,
                            ForexSelling = currencyModel.ForexSelling,
                            Deleted = currencyModel.Deleted,
                            UpdateDate = currencyModel.UpdateDate,
                            ChangeDate = currencyModel.ChangeDate,
                        });
                    }
                }
            }
            this.connectionProperty.Close();
        }
        public void UpdateCurrencyRate(List<CurrencyRate> currenyRateList)
        {
            this.connectionProperty = DbConnection(connectionProperty);
            var lastCurrencyRateList = SelectCurrencyRate();
            string sql = @"UPDATE CurrencyRate SET CurrencyCode = @CurrencyCode, Unit = @Unit, FirstCurrency = @FirstCurrency, CrossRate = @CrossRate, SecondCurrency = @SecondCurrency, UpdateDate = @UpdateDate";
            foreach (var item in currenyRateList)
            {
                var currencyRateModel = lastCurrencyRateList.Where(x => x.CurrencyCode == item.CurrencyCode).First();
                if (!string.IsNullOrWhiteSpace(currencyRateModel.CurrencyCode))
                {
                    var UpdateData = connectionProperty.Execute(sql, new CurrencyRate
                    {
                        CurrencyCode = currencyRateModel.CurrencyCode,
                        Unit = currencyRateModel.Unit,
                        FirstCurrency = currencyRateModel.FirstCurrency,
                        CrossRate = currencyRateModel.CrossRate,
                        SecondCurrency = currencyRateModel.SecondCurrency,
                        UpdateDate = currencyRateModel.UpdateDate
                    });
                }
            }
            this.connectionProperty.Close();
        }
    }
}
