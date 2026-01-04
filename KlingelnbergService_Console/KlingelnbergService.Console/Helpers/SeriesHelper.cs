using System;
using System.Text.RegularExpressions;

namespace KlingelnbergService.Helpers
{

    public static class SeriesHelper
    {
        //extract the numeric value from the series
        public static int GetSeriesValue(string seriesName)
        {
            if (string.IsNullOrWhiteSpace(seriesName))
                throw new ArgumentException("Series number can not be null or empty");

            var match = Regex.Match(seriesName.Trim(), @"S(\d+)$", RegexOptions.IgnoreCase);
            // (S6, --- , caseIgnore)

            if (!match.Success)
                throw new ArgumentException($"Invalid series fromat : {seriesName}. Expected format : S<digit>", nameof(seriesName));
            
            // match.Groups[0] - whole match 
            // match.Groups[1] - digits only 

            int number = int.Parse(match.Groups[1].Value);
            return number;
        }

        // validate the series format
        public static bool IsValidSeriesFormat(string seriesName)
        {
            if(string.IsNullOrWhiteSpace(seriesName))
                return false;

            return Regex.IsMatch(seriesName.Trim(), @"S(\d+)$", RegexOptions.IgnoreCase);
        }
    }
}
