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

    private bool isTournament;

    private void Awake() {
        calendarEventReader.calendarChanged += OnCalendarChange;
        OnCalendarChange(SaveData.current.calendar);
    }

    private void OnDestroy() {
        calendarEventReader.calendarChanged -= OnCalendarChange;
    }
    public void OnCalendarChange(Calendar calendar){
        SetCurrentDate(calendar.GetCurrentMonth());
        SetIfTournament(calendar);
    }

    public void OnClick(){
        if(isTournament) OnPlayClick();
        else OnNextClick();
    }

    public void OnNextClick(){
        SaveData.current.calendar.NextMonth(calendarEventReader);
    }

    public void OnPlayClick(){
        Debug.Log("OnPlayClick");
        OnNextClick();
    }
    private void SetCurrentDate(int month){
        currentDateTxt.text = "Month #" + month;
    }

    private void SetIfTournament(Calendar calendar){
        if(calendar.GetScheduleCalendar()[calendar.GetCurrentMonth()] == CalendarEvent.TOURNAMENT){
            isTournament = true;
            nextTxt.text = "PLAY";
            tournamentTxtObj.SetActive(true);
        }else{
            isTournament = false;
            nextTxt.text = "NEXT";
            tournamentTxtObj.SetActive(false);
        }
    }
}
