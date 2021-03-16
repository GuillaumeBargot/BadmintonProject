using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScene : GameScene
{
    [SerializeField]
    private SaveManager saveManager;

    [SerializeField]
    private Button continueButton;

    private bool continueAvailable;

    protected override void Awake()
    {
        base.Awake();
        SetContinueAvailable(saveManager.GetCurrentSave() != -1);
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
                navigationManager.LaunchScene(NavigationManager.SceneName.NewGameScene, this, true);
                break;
            case 2:
                navigationManager.LaunchScene(NavigationManager.SceneName.LoadScene, this, true);
                break;
            case 3:
                navigationManager.LaunchScene(NavigationManager.SceneName.MatchScene, this, true);
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

    private void LoadGame()
    {
        int currentSave = saveManager.GetCurrentSave();
        saveManager.Load(currentSave);
        navigationManager.LaunchScene(NavigationManager.SceneName.HomeScene,this,true);
    }

    private void SetContinueAvailable(bool available)
    {
        continueButton.interactable = available;
    }
}
