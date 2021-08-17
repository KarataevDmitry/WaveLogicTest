using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveLogicTestWinForms.Extensions
{
    public static class TimeSpanExtensions
    {
        public static string ToDepthValueInDays(this TimeSpan ts) => $"{ts.TotalDays}d";
        
    }
}
