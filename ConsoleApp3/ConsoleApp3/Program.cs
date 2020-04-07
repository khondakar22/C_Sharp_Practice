using System;
using System.Globalization;
using System.IO;
using System.Collections.ObjectModel;

public class Program
{
    public static void Main()
    {
        //const string outputfilename = @"C:\Temp\TimeZoneInfo.txt";

        //DateTimeFormatInfo dateFormats = CultureInfo.CurrentCulture.DateTimeFormat;
        //ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
        //StreamWriter sw = new StreamWriter(outputfilename, false);

        //sw.WriteLine("Date Format: {0,1}", dateFormats.FullDateTimePattern);
        //foreach (TimeZoneInfo timeZone in timeZones)
        //{
        //    bool hasDST = timeZone.SupportsDaylightSavingTime;
        //    TimeSpan offsetFromUtc = timeZone.BaseUtcOffset;
        //    TimeZoneInfo.AdjustmentRule[] adjustRules;
        //    string offsetString;

        //    sw.WriteLine("ID: {0}", timeZone.Id);
        //    sw.WriteLine("   Display Name: {0, 40}", timeZone.DisplayName);
        //    sw.WriteLine("   Standard Name: {0, 39}", timeZone.StandardName);
        //    sw.Write("   Daylight Name: {0, 39}", timeZone.DaylightName);
        //    sw.Write(hasDST ? "   ***Has " : "   ***Does Not Have ");
        //    sw.WriteLine("Daylight Saving Time***");
        //    offsetString = String.Format("{0} hours, {1} minutes", offsetFromUtc.Hours, offsetFromUtc.Minutes);
        //    sw.WriteLine("   Offset from UTC: {0, 40}", offsetString);
        //    adjustRules = timeZone.GetAdjustmentRules();
        //    sw.WriteLine("   Number of adjustment rules: {0, 26}", adjustRules.Length);

        //    if (adjustRules.Length > 0)
        //    {
        //        sw.WriteLine("   Adjustment Rules:");
        //        foreach (TimeZoneInfo.AdjustmentRule rule in adjustRules)
        //        {
        //            TimeZoneInfo.TransitionTime transTimeStart = rule.DaylightTransitionStart;
        //            TimeZoneInfo.TransitionTime transTimeEnd = rule.DaylightTransitionEnd;

        //            sw.WriteLine("      From {0} to {1}", rule.DateStart, rule.DateEnd);
        //            sw.WriteLine("      Delta: {0}", rule.DaylightDelta);
        //            if (!transTimeStart.IsFixedDateRule)
        //            {
        //                sw.WriteLine("      Begins at {0:t} on {1} of week {2} of {3}", transTimeStart.TimeOfDay,
        //                                                                              transTimeStart.DayOfWeek,
        //                                                                              transTimeStart.Week,
        //                                                                              dateFormats.MonthNames[transTimeStart.Month - 1]);
        //                sw.WriteLine("      Ends at {0:t} on {1} of week {2} of {3}", transTimeEnd.TimeOfDay,
        //                                                                              transTimeEnd.DayOfWeek,
        //                                                                              transTimeEnd.Week,
        //                                                                              dateFormats.MonthNames[transTimeEnd.Month - 1]);
        //            }
        //            else
        //            {
        //                sw.WriteLine("      Begins at {0:t} on {1} {2}", transTimeStart.TimeOfDay,
        //                                                               transTimeStart.Day,
        //                                                               dateFormats.MonthNames[transTimeStart.Month - 1]);
        //                sw.WriteLine("      Ends at {0:t} on {1} {2}", transTimeEnd.TimeOfDay,
        //                                                             transTimeEnd.Day,
        //                                                             dateFormats.MonthNames[transTimeEnd.Month - 1]);
        //            }
        //        }
        //    }
        //}
        //sw.Close();

        //string displayName = "(GMT+06:00) Antarctica/Mawson Time";
        //string standardName = "Mawson Time";
        //TimeSpan offset = new TimeSpan(06, 00, 00);
        //TimeZoneInfo dateandtimeFormate = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName);
        //Console.WriteLine("The current time is {0} {1}",
        //    TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, dateandtimeFormate),
        //    dateandtimeFormate.StandardName);

        DateTime timeUtc = DateTime.UtcNow;
        try
        {
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
            DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
            Console.WriteLine("The date and time are {0} {1}.",
                cstTime,
                cstZone.IsDaylightSavingTime(cstTime) ?
                    cstZone.DaylightName : cstZone.StandardName);

            if (cstZone.IsDaylightSavingTime(cstTime))
            {
                var accurateTime = cstZone.GetUtcOffset(timeUtc);
                var result = DateTime.Parse(timeUtc.ToString(CultureInfo.CurrentCulture));
                
                Console.WriteLine(cstZone.GetUtcOffset(timeUtc));
                Console.WriteLine(result);
                Console.WriteLine(cstZone.DaylightName);
            }
        }
        catch (TimeZoneNotFoundException)
        {
            Console.WriteLine("The registry does not define the Central Standard Time zone.");
        }
        catch (InvalidTimeZoneException)
        {
            Console.WriteLine("Registry data on the Central Standard Time zone has been corrupted.");
        }
    }
}