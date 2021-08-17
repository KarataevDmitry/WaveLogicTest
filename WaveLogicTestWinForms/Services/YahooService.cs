using Newtonsoft.Json.Linq;
using System;
using System.Net;
using WaveLogicTestWinForms.Model;
using WaveLogicTestWinForms.Model.JSON;
using WaveLogicTestWinForms.Exceptions;
using WaveLogicTestWinForms.Extensions;


namespace WaveLogicTestWinForms.Services
{
    public class YahooService
    {
        private WebClient wc = new WebClient();
        private StockDataStore ds = new StockDataStore();
        public StockDataStore Store { get => ds; }
        public YahooService()
        {

        }
        public StockDataStore GetJSONData(StockInfo stockInfo)
        {
            if (string.IsNullOrEmpty(stockInfo.DepthPattern))
            {
                throw new NoDepthPatternProvidedException();
            }

            PerformQuery(stockInfo);
            return Store;
        }

        private void PerformQuery(StockInfo stockInfo)
        {
            var offsetInDays = stockInfo.DepthPattern.ToDepthDays(stockInfo.StartDate);
            var jsonQuerry = $"https://query1.finance.yahoo.com/v7/finance/chart/AAPL?range={offsetInDays}d&interval=1d&indicators=quote&includeTimestamps=true&view=detail";
            var qRes = wc.DownloadString(jsonQuerry);
            var queryResult = JObject.Parse(qRes);
            Rootobject rootobject = queryResult.ToObject<Rootobject>();

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
                    ds.Add(new StockData(date, open_i, high_i, low_i, close_i, adjClose_i, volume_i));
                }


            }
        }
    }
}

