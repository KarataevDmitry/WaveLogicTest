﻿namespace WaveLogicTestWinForms.Model.JSON
{
    public class Meta
    {
        public string currency { get; set; }
        public string symbol { get; set; }
        public string exchangeName { get; set; }
        public string instrumentType { get; set; }
        public int firstTradeDate { get; set; }
        public int regularMarketTime { get; set; }
        public int gmtoffset { get; set; }
        public string timezone { get; set; }
        public string exchangeTimezoneName { get; set; }
        public float regularMarketPrice { get; set; }
        public float chartPreviousClose { get; set; }
        public int priceHint { get; set; }
        public Currenttradingperiod currentTradingPeriod { get; set; }
        public string dataGranularity { get; set; }
        public string range { get; set; }
        public string[] validRanges { get; set; }
    }

}
