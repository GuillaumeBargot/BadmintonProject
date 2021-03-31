using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class CoachNamePopup : Popup
{

    [SerializeField]
    private TMP_InputField inputField;


    [SerializeField]
    private SaveManager saveManager;

    private UnityAction launchSceneAction;
    private int selectedSlot;
    public void OnGoClick(){
        if(inputField.text == ""){
            Debug.LogError("InputField empty");
        }else{
            SaveData.NewGame(inputField.text,selectedSlot);
            saveManager.Save();
            launchSceneAction.Invoke();
        }
    }

    public void SetSelectedSlot(int number){
        selectedSlot = number;
    }

    public void SetLaunchSceneMethod(UnityAction launchSceneAction){
        this.launchSceneAction = launchSceneAction;
    }
}
