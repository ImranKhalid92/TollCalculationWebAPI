using System;
using System.Collections.Generic;

namespace TollCalculation.Common
{
    public enum TollPlaza
    {
        ZeroPoint = 0,
        NSInterchange = 5,
        Ph4Interchange = 10,
        FerozpurInterchange = 17,
        LakeCityInterchange = 24,
        RaiwandInterchange = 29,
        BahriaInterchange = 34
    }
    public class Rates
    {
        public static double BaseRate = 20;
        public static double DistanceRatePerKM = 0.2;
        public static double DistanceRateOnWeekendPerKM = DistanceRatePerKM * 1.5;
        public static double DiscountOnMonWed = 0.10;
        public static double DiscountOnTuesdayThursday = 0.10;
        public static double DiscountOnHolidays = 0.50;

    }

    public class HelpingData
    {
        public static List<DateTime> Holidays = new List<DateTime> { new DateTime(2022,03,23), new DateTime(2022,08,14), new DateTime(2022,12,25) };
        public static List<DayOfWeek> MonWed = new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Wednesday};
        public static List<DayOfWeek> TuesdayThursday = new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Thursday};
        public static List<DayOfWeek> FrySaturSunday = new List<DayOfWeek> { DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday};
        public static List<DayOfWeek> SaturSunday = new List<DayOfWeek> {  DayOfWeek.Saturday, DayOfWeek.Sunday};
    }


}
