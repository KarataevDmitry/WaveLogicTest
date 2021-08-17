using System;
using System.Text.RegularExpressions;

namespace WaveLogicTestWinForms.Extensions
{
    public static class StringExtensions
    {
        static Regex depthRegex = new Regex(@"(\d{1,2})+([dym]{1})+");
        public static int ToDepthDays(this string s, DateTime startPoint)
        {
            
            DateTime offset = startPoint;
            if (IsDepthString(s))
            {
                foreach (Match m in depthRegex.Matches(s))
                {

                    if (m.Value.EndsWith("m"))
                    {
                        int monthCount = int.Parse(m.Value.Replace("m", ""));
                        offset = offset.AddMonths(-monthCount);
                    }
                    if (m.Value.EndsWith("d"))
                    {
                        int daysCount = int.Parse(m.Value.Replace("d", ""));
                        offset = offset.AddDays(-daysCount);
                    }
                    if (m.Value.EndsWith("y"))
                    {
                        int yearsCount = int.Parse(m.Value.Replace("y", ""));
                        offset = offset.AddYears(-yearsCount);
                    }
                }
            }
            var offsetInDays = (startPoint - offset).TotalDays;
            return (int)offsetInDays;
        }
        public static bool IsDepthString(this string s )
        {
            return depthRegex.IsMatch(s);
        }
    }
}
