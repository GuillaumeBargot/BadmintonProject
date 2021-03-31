using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Calendar
{
    private CalendarEvent[] scheduledCalendar;

    private int currentMonth = -1;

    private CalendarState calendarState = CalendarState.POST_SEASON;

    private Tournament tournament = null;

    public bool isTournamentNow = false;

    public Calendar()
    {
        currentMonth = 0;
        scheduledCalendar = new CalendarEvent[10];
        for (int i = 0; i < 10; i++)
        {
            switch (i)
            {
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
        calendarState = CalendarState.POST_SEASON;
    }

    public CalendarEvent[] GetScheduleCalendar()
    {
        return scheduledCalendar;
    }

    public int GetCurrentMonth()
    {
        return currentMonth;
    }

    public Tournament GetTournament()
    {
        return tournament;
    }

    public void NewTournament()
    {
        tournament = new Tournament();
        //For now, creating a match:
        tournament.CreateMatch(PlayerSave.CreateRandomCPU());
    }

    public void NextMonth(CalendarEventReader eventReader)
    {
        this.currentMonth++;
        if (currentMonth >= scheduledCalendar.Length)
        {
            calendarState = CalendarState.END_OF_SEASON;
            eventReader.OnCalendarStateChanged(CalendarState.END_OF_SEASON);
        }
        else
        {
            eventReader.OnCalendarDateChanged(this);
        
            if (scheduledCalendar[currentMonth] == CalendarEvent.TOURNAMENT)
            {
                isTournamentNow = true;
            }
            else
            {
                isTournamentNow = false;
                tournament = null;
            }
        }

    }

    public void StartSeason()
    {
        currentMonth = 0;
    }

    public void SetCalendarState(CalendarState calendarState, CalendarEventReader eventReader)
    {
        this.calendarState = calendarState;
        eventReader.OnCalendarStateChanged(calendarState);
    }

    public void FinishTournament(CalendarEventReader eventReader)
    {
        this.calendarState = CalendarState.SEASON;
        this.tournament.Finish();
        if (currentMonth >= scheduledCalendar.Length)
        {
            calendarState = CalendarState.END_OF_SEASON;
            eventReader.OnCalendarStateChanged(CalendarState.END_OF_SEASON);
        }

    }

    public CalendarState GetCalendarState()
    {
        return calendarState;
    }
}
