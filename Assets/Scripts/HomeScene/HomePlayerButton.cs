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
    // Start is called before the first frame update

    public UnityEvent clickPlayerEvent;

    public UnityEvent clickNoPlayerEvent;

    bool playerExists = false;
    void Awake()
    {
        /*clickNoPlayerAction = new UnityEvent(Nothing);
        clickPlayerAction = new UnityEvent(Nothing);*/
        CheckForExistingPlayer();
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
        if(playerExists) clickPlayerEvent.Invoke();
        else clickNoPlayerEvent.Invoke();
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
}
