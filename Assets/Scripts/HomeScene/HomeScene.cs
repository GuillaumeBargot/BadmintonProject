using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HomeScene : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI coachNameText;

    [SerializeField]
    HomePlayerButton playerButton;

    [SerializeField]
    SaveManager saveManager;

    private void Awake() {
        coachNameText.text = SaveData.current.profile.playerName;
    }

    private void Start() {
        playerButton.clickPlayerEvent.AddListener(GoToPlayerProfileScene);
        playerButton.clickNoPlayerEvent.AddListener(CreateNewPlayer);
    }

    private void OnDestroy() {
        playerButton.clickPlayerEvent.RemoveAllListeners();
        playerButton.clickNoPlayerEvent.RemoveAllListeners();
    }

    private void GoToPlayerProfileScene(){
        Debug.Log("Clicked on Player");
        //Empty for now
    }

    private void CreateNewPlayer(){
        Debug.Log("Created new player");
        SaveData.current.playerSave = new PlayerSave(new Player("NoName ForNow"));
        playerButton.Refresh();
    }

    public void OnSaveClick(){
        saveManager.Save();
    }
    
}
