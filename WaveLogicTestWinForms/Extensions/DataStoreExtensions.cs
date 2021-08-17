using iText.Layout;
using iText.Layout.Element;
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
                    g.Sum(x => x.Volume)
                    );
                ds.Add(sd);
            }
            return ds;
        }
        public static DataTable ToDataTable(this StockDataStore ds)
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
        public static void ExportToPDF(this StockDataStore dt, string fileName)
        {
            void WriteListToPdf(Document doc)
            {
                Table table = new Table(8);
                table.AddHeaderCell("Date");
                table.AddHeaderCell(nameof(StockData.Open));
                table.AddHeaderCell(nameof(StockData.High));
                table.AddHeaderCell(nameof(StockData.Low));
                table.AddHeaderCell(nameof(StockData.Close));
                table.AddHeaderCell(nameof(StockData.Adjclose));
                table.AddHeaderCell(nameof(StockData.Volume));
                table.StartNewRow();
                foreach (var item in dt)
                {
                    table.AddCell(item.Date.ToString("dd.MM.yyyy HH:mm:ss"));
                    table.AddCell(item.Open.ToString());
                    table.AddCell(item.High.ToString());
                    table.AddCell(item.Low.ToString());
                    table.AddCell(item.Close.ToString());
                    table.AddCell(item.Adjclose.ToString());
                    table.AddCell(item.Volume.ToString());
                    table.StartNewRow();
                }



                doc.Add(table);
                doc.Close();

            }
            var doc = new Document(new iText.Kernel.Pdf.PdfDocument(new iText.Kernel.Pdf.PdfWriter(fileName)));
            WriteListToPdf(doc);
        }
    }
  
}
