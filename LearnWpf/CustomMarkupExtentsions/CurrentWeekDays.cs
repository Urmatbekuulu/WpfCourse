using System;
using System.Collections.ObjectModel;
using System.Windows.Markup;

namespace LearnXAML.CustomMarkupExtentsions; 

public class CurrentWeekDays:MarkupExtension {
    public string Format { get; set; } = "yyyy MMMM dd";
    public DayOfWeek StartDayOfWeek { get; set; } = DayOfWeek.Monday;
   
    public override object ProvideValue(IServiceProvider serviceProvider) {
        
        var weekDays = new Collection<string>();
        var today = DateTime.Now.DayOfWeek;
        var startDay = DateTime.Today.AddDays((int)StartDayOfWeek-(int)today);
        var endDay = startDay.AddDays(Enum.GetNames<DayOfWeek>().Length);
        
        var day = startDay;
        
        while(day < endDay)
        {
            weekDays.Add($"{(today==day.DayOfWeek?"Today is ":"")}{day.DayOfWeek} - {day.ToString(Format)}");
            day = day.AddDays(1);
        }
        
        return weekDays;
    }
}