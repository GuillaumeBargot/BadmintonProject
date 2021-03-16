using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Calendar {
    private CalendarEvent[] scheduledCalendar;

    private int currentMonth = -1;

    public Calendar(){
        scheduledCalendar = new CalendarEvent[10];
        for(int i = 0; i < 10; i ++){
            switch(i){
                case 2:
                case 4:
                case 7:
                case 9:
                scheduledCalendar[i] = CalendarEvent.TOURNAMENT;
                break;
                default:
                scheduledCalendar[i] = CalendarEvent.NOTHING;
                break;
            }
        }
    }

    public CalendarEvent[] GetScheduleCalendar(){
        return scheduledCalendar;
    }

    public int GetCurrentMonth(){
        return currentMonth;
    }

    public void NextMonth(CalendarEventReader eventReader){
        currentMonth++;
        eventReader.OnCalendarChanged(this);
    }
}
