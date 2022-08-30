using System.Globalization;

namespace TestDueWeek2And4
{
    internal class DueDateClass
    {
        public static void GenerateDue(int year)
        {
            Console.WriteLine("#------------------- START" + year + "-------------------#");
            int due15 = 14;
            DayOfWeek cutOfDay = DayOfWeek.Wednesday;
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar calendar = dfi.Calendar;

            for (int month = 1; month < 13; month++)
            {
                DateTime firstDayInMonth = new(year, month, 1);
                DateTime lastDayInMonth = new(year, month, calendar.GetDaysInMonth(year, month));

                int week2 = calendar.GetWeekOfYear(firstDayInMonth, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) + 1;
                int week4 = week2 + 2;
                while (firstDayInMonth < lastDayInMonth)
                {
                    int curWeekNum = calendar.GetWeekOfYear(firstDayInMonth, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                    if (firstDayInMonth.DayOfWeek == cutOfDay &&
                        (curWeekNum == week2 || curWeekNum == week4))
                    {
                        Console.WriteLine(string.Format("{0} Week {1} CutOf {2} Due15 {3} Due30 {4}",
                                                        firstDayInMonth.ToString("MMMM"),
                                                       curWeekNum,
                                                        firstDayInMonth.ToString("dd/MM/yyyy"),
                                                        firstDayInMonth.AddDays(due15).ToString("dd/MM/yyyy"),
                                                        firstDayInMonth.AddMonths(1).ToString("dd/MM/yyyy")));
                        firstDayInMonth = firstDayInMonth.AddDays(14);
                    }
                    else
                    {
                        firstDayInMonth = firstDayInMonth.AddDays(1);
                    }
                }
            }
            Console.WriteLine("#-------------------END" + year + "-------------------#\n");
        }
    }
}
