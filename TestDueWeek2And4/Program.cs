// See https://aka.ms/new-console-template for more information
using System.Globalization;

int year = 2022;
int due15 = 14;
DayOfWeek cutOfDay = DayOfWeek.Wednesday;
DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
Calendar calendar = dfi.Calendar;

for (int month = 1; month < 13; month++)
{
    DateTime firstDayInMonth = new(year, month, 1);
    DateTime lastDayInMonth = new(year, month, calendar.GetDaysInMonth(year, month));

    int week2 = calendar.GetWeekOfYear(firstDayInMonth, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) + 1;
    int week4 = calendar.GetWeekOfYear(firstDayInMonth, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) + 3;
    while (firstDayInMonth < lastDayInMonth)
    {
        if (firstDayInMonth.DayOfWeek == cutOfDay && 
            (calendar.GetWeekOfYear(firstDayInMonth, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) == week2
            || calendar.GetWeekOfYear(firstDayInMonth, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) == week4))
        {
            Console.WriteLine(string.Format("{0} Week {1} CutOf {2} Due15 {3} Due30 {4}", 
                                            firstDayInMonth.ToString("MMMM"),
                                            calendar.GetWeekOfYear(firstDayInMonth, dfi.CalendarWeekRule, dfi.FirstDayOfWeek),
                                            firstDayInMonth.ToString("dd/MM/yyyy"),
                                            firstDayInMonth.AddDays(due15).ToString("dd/MM/yyyy"),
                                            firstDayInMonth.AddMonths(1).ToString("dd/MM/yyyy")));
            firstDayInMonth = firstDayInMonth.AddDays(13);
        }
        else
        {
            firstDayInMonth = firstDayInMonth.AddDays(1);
        }
   }
}
