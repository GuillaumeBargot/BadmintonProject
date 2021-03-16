using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    protected override void Awake() {
        base.Awake();
        coachNameText.text = SaveData.current.profile.playerName;
        playerButton.SetLaunchPlayerProfileAction(LaunchPlayerProfile);
    }

    public void OnSaveClick(){
        saveManager.Save();
    }

    public void LaunchPlayerProfile(){
        navigationManager.LaunchScene(NavigationManager.SceneName.PlayerProfileScene, this, true);
    }

    /*public void OnBackClick(){
        Debug.Log("ON SAVE CLICK");
        saveManager.Save();
        navigationManager.LaunchScene(NavigationManager.SceneName.MainMenuScene,this);
        //StartCoroutine(GoToMainMenu());
    }*/
}
