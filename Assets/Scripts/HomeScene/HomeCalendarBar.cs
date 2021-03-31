using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class HomeCalendarBar : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI currentDateTxt;

    [SerializeField]
    private GameObject tournamentTxtObj;

    [SerializeField]
    private TextMeshProUGUI nextTxt;

    [SerializeField]
    private CalendarEventReader calendarEventReader;


    private UnityAction startTournamentAction;

    private void OnEnable()
    {
        calendarEventReader.calendarDateChanged += OnCalendarChange;
        Refresh();
    }

    public void Refresh(){
        OnCalendarChange(SaveData.current.calendar);
    }
    private void OnDisable()
    {
        calendarEventReader.calendarDateChanged -= OnCalendarChange;
    }
    public void OnCalendarChange(Calendar calendar)
    {
        SetCurrentDate(calendar.GetCurrentMonth());
        SetIfTournament(calendar);
    }

    public void OnClick()
    {
        if (SaveData.current.calendar.isTournamentNow && SaveData.current.calendar.GetTournament()==null) OnPlayClick();
        else OnNextClick();
    }

    public void OnNextClick()
    {
        SaveData.current.calendar.NextMonth(calendarEventReader);
    }

    public void OnPlayClick()
    {
        startTournamentAction.Invoke();
    }
    private void SetCurrentDate(int month)
    {
        currentDateTxt.text = "Month #" + month;
    }

    private void SetIfTournament(Calendar calendar)
    {
        if (calendar.GetCurrentMonth() >= 0 && calendar.GetCurrentMonth()<calendar.GetScheduleCalendar().Length)
        {
            if (calendar.GetScheduleCalendar()[calendar.GetCurrentMonth()] == CalendarEvent.TOURNAMENT && calendar.GetTournament() == null)
            {
                nextTxt.text = "PLAY";
                tournamentTxtObj.SetActive(true);
            }
            else
            {
                nextTxt.text = "NEXT";
                tournamentTxtObj.SetActive(false);
            }
        }
    }

    public void SetStartTournamentAction(UnityAction action)
    {
        startTournamentAction = action;
    }
}
