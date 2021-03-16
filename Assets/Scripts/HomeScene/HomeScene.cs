using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HomeScene : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI coachNameText;

    [SerializeField]
    HomePlayerButton playerButton;

    [SerializeField]
    SaveManager saveManager;
    [SerializeField]
    HomeCalendarBar calendarBar;

    private void Awake() {
        coachNameText.text = SaveData.current.profile.playerName;
    }

    public void OnSaveClick(){
        saveManager.Save();
    }

    public void OnBackClick(){
        saveManager.Save();
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
