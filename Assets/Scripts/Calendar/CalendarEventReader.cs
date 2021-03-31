using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CalendarEventReader", menuName = "Events/CalendarEventReader")]
public class CalendarEventReader : ScriptableObject
{
    public event UnityAction<Calendar> calendarDateChanged;
    public event UnityAction<CalendarState> calendarStateChanged;

    public void OnCalendarDateChanged(Calendar calendar)
    {
        if (calendarDateChanged != null)
        {
            calendarDateChanged.Invoke(calendar);
        }
    }

    public void OnCalendarStateChanged(CalendarState calendarState)
    {
        if (calendarStateChanged != null)
        {
            calendarStateChanged.Invoke(calendarState);
        }
    }

}
