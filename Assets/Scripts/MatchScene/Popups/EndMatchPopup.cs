using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class EndMatchPopup : Popup
{

    [SerializeField]
    private TextMeshProUGUI title;
    private UnityAction finishEvent;


    public void Init(bool won, UnityAction finishAction){
        SetTitle(won);
        SetFinishEvent(finishAction);
    }
    private void SetTitle(bool won){
        if(!won){
            title.text = "DEFEAT";
        }
    }
    private void SetFinishEvent(UnityAction action){
        finishEvent+=action;
    }

    public void OnFinishClick(){
        if(SaveData.CurrentMatchExists){
                SaveData.current.calendar.GetTournament().currentMatch.matchOver = true;
                finishEvent.Invoke();
                SaveData.current.calendar.GetTournament().EndCurrentMatch();
            }
    }
}
