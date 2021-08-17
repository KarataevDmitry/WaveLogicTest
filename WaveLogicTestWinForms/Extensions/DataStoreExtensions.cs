using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveLogicTestWinForms.Model;

namespace WaveLogicTestWinForms.Extensions
{
    public static class DataStoreExtensions
    {
        public static StockDataStore TransformTo(this StockDataStore original, Period to)
        {
            var ds = new StockDataStore();
            IEnumerable<IGrouping<int, StockData>> grouped = new List<IGrouping<int, StockData>>();
            switch (to)
            {
                case Period.Daily:
                    return original;
                case Period.Weekly:
                    grouped = from data in original
                              group data by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(data.Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday) into weekData
                              select weekData;
                    break;
                case Period.Monthly:
                    grouped = from data in original
                              group data by CultureInfo.CurrentCulture.Calendar.GetMonth(data.Date) into monthData
                              select monthData;
                    break;
                default:
                    break;
            }

            foreach (var g in grouped)
            {
                var sd = new StockData(
                    g.Last().Date,
                    g.Max(x => x.High),
                    g.Min(x => x.Low),
                    g.First().Open,
                    g.Last().Close,
                    g.Last().Adjclose,
                    g.Last().Volume 
                    );
                ds.Add(sd);
            }
            return ds;
        }
        public static DataTable ToDataTable (this StockDataStore ds)
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("date", typeof(DateTime)));
            dt.Columns.Add(new DataColumn(nameof(StockData.Open), typeof(float)));
            dt.Columns.Add(new DataColumn(nameof(StockData.High), typeof(float)));
            dt.Columns.Add(new DataColumn(nameof(StockData.Low), typeof(float)));
            dt.Columns.Add(new DataColumn(nameof(StockData.Close), typeof(float)));
            dt.Columns.Add(new DataColumn(nameof(StockData.Adjclose), typeof(float)));
            dt.Columns.Add(new DataColumn(nameof(StockData.Volume), typeof(float)));
            
            foreach (var data in ds)
            {
                dt.Rows.Add(data.Date, data.Open, data.High, data.Low, data.Close, data.Adjclose, data.Volume);
            }
            return dt;
        }
    }
}
