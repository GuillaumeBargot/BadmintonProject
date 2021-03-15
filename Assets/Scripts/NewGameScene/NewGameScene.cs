using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NewGameScene : MonoBehaviour{
    
    [SerializeField]
    PopupSystem popupSystem;

    [SerializeField]
    CoachNamePopup coachNamePopupPrefab;

    [SerializeField]
    NewSaveSlots newSaveSlots;

    public void OnButtonClicked(){

        CoachNamePopup popup = popupSystem.InstantiatePopup<CoachNamePopup>(coachNamePopupPrefab);
        popup.SetSelectedSlot(newSaveSlots.GetSelectedSlot());
    }

    public void OnBackClick(){
        StartCoroutine(GoToMainMenu());
    }
    
    IEnumerator GoToMainMenu(){
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenuScene");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
