using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TournamentScene : GameScene
{
    [SerializeField]
    private TextMeshProUGUI tournamentStateTxt;

    [SerializeField]
    private Button tournamentFinishBtn;

    [SerializeField]
    private CalendarEventReader calendarEventReader;

    [SerializeField]
    private GameObject nextMatchPanel;

    [SerializeField]
    private TextMeshProUGUI nextMatchTitle;

    [SerializeField]
    private TextMeshProUGUI nextMatchNames;

    protected override void Awake() {
        base.Awake();
        Refresh();
    }
    private void Refresh(){
        if(SaveData.current.calendar.GetTournament()!=null){
            Tournament.TournamentState tournamentState = SaveData.current.calendar.GetTournament().state;
            tournamentStateTxt.text = tournamentState.ToString();
            switch(tournamentState){
                case Tournament.TournamentState.IDLE:
                    //tournamentFinishBtn.gameObject.SetActive(true);
                    nextMatchPanel.SetActive(true);
                    nextMatchTitle.text = "Next match:";
                    tournamentFinishBtn.gameObject.SetActive(false);
                    SetNextMatchNames();
                break;
                case Tournament.TournamentState.MATCH:
                    nextMatchPanel.SetActive(true);
                    nextMatchTitle.text = "Current match";
                    tournamentFinishBtn.gameObject.SetActive(false);
                    SetNextMatchNames();
                break;
                case Tournament.TournamentState.FINISHED:
                    nextMatchPanel.SetActive(false);
                    tournamentFinishBtn.gameObject.SetActive(true);
                break;
            }
            
            
            
        }else{
            Back();
        }
    }
    public void OnTournamentFinishBtn(){
        Back();
    }

    public void OnPlayMatchClick(){
        SaveData.current.calendar.GetTournament().StartMatch();
        navigationManager.LaunchScene(NavigationManager.SceneName.MatchScene, this, true);
    }

    private void Back(){
        if(SaveData.current.calendar.GetTournament()!=null && SaveData.current.calendar.GetTournament().state == Tournament.TournamentState.FINISHED){
            SaveData.current.calendar.FinishTournament(calendarEventReader);
        }
        navigationManager.Back(this);
    }   

    private void SetNextMatchNames(){
        bool isMatch = SaveData.current.calendar.GetTournament().state == Tournament.TournamentState.MATCH;
        string isNullString = "Is null";
        if(isMatch){
            if(SaveData.current.calendar.GetTournament().currentMatch.score!=null){
                (int, int) matchScore = SaveData.current.calendar.GetTournament().currentMatch.score.GetMatchScore();
                isNullString = matchScore.Item1 + "/" + matchScore.Item2;
            }
        }
        nextMatchNames.text = SaveData.current.playerSave.name + "\nVS\n" + SaveData.current.calendar.GetTournament().currentMatch.cpuPlayer.name
        + "\n" + isNullString;
    }
}
