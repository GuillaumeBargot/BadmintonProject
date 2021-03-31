using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeScene : GameScene
{
    [SerializeField]
    TextMeshProUGUI coachNameText;

    [SerializeField]
    HomePlayerButton playerButton;

    [SerializeField]
    SaveManager saveManager;
    [SerializeField]
    HomeCalendarBar calendarBar;

    [SerializeField]
    Button startSeasonButton;

    [SerializeField]
    Button goTournamentBtn;
    [SerializeField]
    CalendarEventReader calendarEventReader;

    [SerializeField]
    Button killPlayerBtn;

    protected override void Awake() {
        base.Awake();
        coachNameText.text = SaveData.current.profile.playerName;
        playerButton.SetLaunchPlayerProfileAction(LaunchPlayerProfile);
        calendarBar.SetStartTournamentAction(StartTournament);
        calendarEventReader.calendarStateChanged += OnCalendarStateChanged;
        calendarEventReader.OnCalendarStateChanged(SaveData.current.calendar.GetCalendarState());
    }

    private void OnDestroy() {
        calendarEventReader.calendarStateChanged -= OnCalendarStateChanged;
    }
    public void OnSaveClick(){
        saveManager.Save();
    }

    public void LaunchPlayerProfile(){
        navigationManager.LaunchScene(NavigationManager.SceneName.PlayerProfileScene, this, true);
    }

    public void StartTournament(){
        SaveData.current.calendar.SetCalendarState(CalendarState.TOURNAMENT, calendarEventReader);
    }

    private void OnCalendarStateChanged(CalendarState calendarState){
        switch(calendarState){
            case CalendarState.POST_SEASON:
                calendarBar.gameObject.SetActive(false);
                playerButton.gameObject.SetActive(false);
                startSeasonButton.gameObject.SetActive(true);
                goTournamentBtn.gameObject.SetActive(false);
                killPlayerBtn.gameObject.SetActive(false);
            break;
            case CalendarState.SEASON:
                calendarBar.gameObject.SetActive(true);
                calendarBar.Refresh();
                playerButton.gameObject.SetActive(true);
                startSeasonButton.gameObject.SetActive(false);
                goTournamentBtn.gameObject.SetActive(false);
                killPlayerBtn.gameObject.SetActive(false);
            break;
            case CalendarState.TOURNAMENT:
                calendarBar.gameObject.SetActive(false);
                playerButton.gameObject.SetActive(true);
                startSeasonButton.gameObject.SetActive(false);
                goTournamentBtn.gameObject.SetActive(true);
                killPlayerBtn.gameObject.SetActive(false);
            break;
            case CalendarState.END_OF_SEASON:
                calendarBar.gameObject.SetActive(false);
                playerButton.gameObject.SetActive(true);
                startSeasonButton.gameObject.SetActive(false);
                goTournamentBtn.gameObject.SetActive(false);
                killPlayerBtn.gameObject.SetActive(true);
            break;
        }
    }

    public void OnStartSeasonClick(){
        SaveData.current.playerSave = new PlayerSave(new Player(PlayerFirstNameGenerator.GetFirstName()));
        SaveData.current.calendar.StartSeason();
        SaveData.current.calendar.SetCalendarState(CalendarState.SEASON,calendarEventReader);
        Refresh();
    }

    public void OnTournamentBtn(){
        Debug.Log("Should go to tournament");
        if(SaveData.current.calendar.GetTournament()==null){
            SaveData.current.calendar.NewTournament();
        }
        navigationManager.LaunchScene(NavigationManager.SceneName.TournamentScene,this,true);
    }

    public void OnKillPlayer(){
        SaveData.current.calendar.SetCalendarState(CalendarState.POST_SEASON, calendarEventReader);
    }

    public void Refresh(){
        playerButton.Refresh();
    }
}
