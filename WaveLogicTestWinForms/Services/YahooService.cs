using CsvHelper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WaveLogicTestWinForms.Model;
using WaveLogicTestWinForms.Model.JSON;
using WaveLogicTestWinForms.Exceptions;
using WaveLogicTestWinForms.Extensions;
using CsvHelper.Configuration;

namespace WaveLogicTestWinForms.Services
{
    public class YahooService
    {
        private WebClient wc = new WebClient();
        
        public YahooService()
        {

        }
        public StockDataStore GetJSONData(StockInfo stockInfo)
        {
            if (string.IsNullOrEmpty(stockInfo.DepthPattern))
            {
                throw new NoDepthPatternProvidedException();
            }


            var offsetInDays = stockInfo.DepthPattern.ToDepthDays(stockInfo.StartDate);
            var jsonQuerry = $"https://query1.finance.yahoo.com/v7/finance/chart/AAPL?range={offsetInDays}d&interval=1d&indicators=quote&includeTimestamps=true&view=detail";
            var qRes = wc.DownloadString(jsonQuerry);
            var queryResult = JObject.Parse(qRes);
            Rootobject rootobject = queryResult.ToObject<Rootobject>();
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("date", typeof(DateTime)));
            dt.Columns.Add(new DataColumn(nameof(Quote.open),        typeof(float)));
            dt.Columns.Add(new DataColumn(nameof(Quote.high),        typeof(float)));
            dt.Columns.Add(new DataColumn(nameof(Quote.low),         typeof(float)));
            dt.Columns.Add(new DataColumn(nameof(Quote.close),       typeof(float)));
            dt.Columns.Add(new DataColumn(nameof(Adjclose.adjclose), typeof(float)));
            dt.Columns.Add(new DataColumn(nameof(Quote.volume),      typeof(float)));
            Quote[] quotes = rootobject.chart.result[0].indicators.quote;
            Adjclose[] adjclose = rootobject.chart.result[0].indicators.adjclose;
            int[] unixtimes = rootobject.chart.result[0].timestamp;
            StockDataStore stockValues = new StockDataStore();
            for (int i = 0; i < quotes.Length; i++)
            {
                for (int j = 0; j < offsetInDays; j++)
                {
                    var date = DateTimeOffset.FromUnixTimeSeconds(unixtimes[j]).DateTime;
                    var open_i = quotes[i].open[j];
                    var high_i = quotes[i].high[j];
                    var low_i = quotes[i].low[j];
                    var close_i = quotes[i].close[j];
                    var adjClose_i = adjclose[i].adjclose[j];
                    var volume_i = quotes[i].volume[j];
                    stockValues.Add(new StockData(date, open_i, high_i, low_i, close_i, adjClose_i, volume_i));
                }
                
               
            }
            return stockValues;
        }
        //public StockDataStore TransformToWeekly(StockDataStore original)
        //{
        //    original.GroupBy(i => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
        //        i.Date,
        //        CalendarWeekRule.FirstDay, DayOfWeek.Monday));
        //}
        //public DataTable GetCSVData(StockInfo stockInfo)
        //{
        //    var unixStartDate = ((DateTimeOffset)stockInfo.StartDate).ToUnixTimeSeconds();
        //    var unixEndDate = ((DateTimeOffset)stockInfo.EndDate).ToUnixTimeSeconds();
        //    var stockName = stockInfo.StockName;
        //    var csvQuerry = $"https://query1.finance.yahoo.com/v7/finance/download/{stockName}?period1={unixStartDate}&period2={unixEndDate}&interval=1d&events=history&crumb=tO1hNZoUQeQ";
        //    wc.DownloadFile(csvQuerry, $@"{stockName}.csv");
        //    using var reader = new StreamReader($@"{stockName}.csv");
        //    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        //    {
        //        PrepareHeaderForMatch = args => args.Header.ToLower().Replace(" ", "")
        //    };
        //    using var csv = new CsvReader(reader, c );

        //    // Do any configuration to `CsvReader` before creating CsvDataReader.
        //    using var dr = new CsvDataReader(csv);
        //    var dt = new DataTable();
        //    dt.Load(dr);
        //    return dt;
        //}
    }
}
