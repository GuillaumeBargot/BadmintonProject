using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class HomePlayerButton : MonoBehaviour
{
    [SerializeField]
    Button button;

    [SerializeField]
    TextMeshProUGUI playerNameTxt;

    private UnityAction launchPlayerProfileAction;
    // Start is called before the first frame update

    bool playerExists = false;
    void Awake()
    {
        /*clickNoPlayerAction = new UnityEvent(Nothing);
        clickPlayerAction = new UnityEvent(Nothing);*/
        CheckForExistingPlayer();
    }

    public void SetLaunchPlayerProfileAction(UnityAction action){
        launchPlayerProfileAction = action;
    }
    private void CheckForExistingPlayer(){
        PlayerSave player = SaveData.current.playerSave;
        if(player==null){
            playerExists = false;
            ShowNoPlayer();
        }else{
            playerExists = true;
            ShowPlayerName(player.name);
        }
    }

    public void OnClick(){
        if(playerExists) GoToPlayerProfileScene();
        else CreateNewPlayer();
    }

    private void ShowPlayerName(string name){
        playerNameTxt.text = name;
    }

    private void ShowNoPlayer(){
        playerNameTxt.text = "Create a player";
    }

    public void Refresh(){
        CheckForExistingPlayer();
    }

    private void Nothing(){

    }

    private void CreateNewPlayer(){
        Debug.Log("Created new player");
        SaveData.current.playerSave = new PlayerSave(new Player("NoName ForNow"));
        Refresh();
    }

    private void GoToPlayerProfileScene(){
        Debug.Log("Clicked on Player");
        //Empty for now
        launchPlayerProfileAction.Invoke();
    }
}
