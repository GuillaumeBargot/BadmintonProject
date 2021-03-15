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
