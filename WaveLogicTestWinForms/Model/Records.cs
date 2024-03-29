﻿using System;

namespace WaveLogicTestWinForms.Model
{

    public record StockInfo
        (
        DateTime StartDate, 
        DateTime EndDate, 
        string DepthPattern, 
        string StockName);
    public record StockData
        (
        DateTime Date,
        float Open,
        float High,
        float Low,
        float Close,
        float Adjclose,
        float Volume
        );
}
