using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScene : MonoBehaviour
{
   [SerializeField]
   private SaveManager saveManager; 

   [SerializeField]
   private Button continueButton;

   private bool continueAvailable;

   private void Awake() {
        SetContinueAvailable(saveManager.GetCurrentSave()!=-1);
   }

    public void OnButtonClick(int optionNumber)
    {
        // Use a coroutine to load the Scene in the background
        switch (optionNumber)
        {
            case 0:
                LoadGame();
                break;
            case 1:
                GoToScene("NewGameScene");
                break;
            case 2:
                GoToScene("LoadScene");
                break;
            case 3:
                GoToScene("MatchScene");
                break;
            case 4:
            default:
                QuitGame();
                break;
        }
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    private void GoToScene(string sceneName)
    {
        StartCoroutine(LoadYourAsyncScene(sceneName));
    }

    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private void LoadGame(){
        int currentSave = saveManager.GetCurrentSave();
        saveManager.Load(currentSave);
        GoToScene("HomeScene");
    }

    private void SetContinueAvailable(bool available){
        continueButton.interactable = available;
    }
}
