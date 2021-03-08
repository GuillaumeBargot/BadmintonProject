using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class CoachNamePopup : Popup
{

    [SerializeField]
    private TMP_InputField inputField;


    [SerializeField]
    private SaveManager saveManager;


    private int selectedSlot;
    public void OnGoClick(){
        if(inputField.text == ""){
            Debug.LogError("InputField empty");
        }else{
            SaveData.current.profile = new HumanPlayerProfile();
            SaveData.current.profile.playerName = inputField.text;
            saveManager.OnSave(selectedSlot);
            StartCoroutine(GoToHomeScene());
        }
    }

    public void SetSelectedSlot(int number){
        selectedSlot = number;
    }

    IEnumerator GoToHomeScene(){
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("HomeScene");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
