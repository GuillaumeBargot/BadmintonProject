using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NavigationManager", menuName = "Navigation/NavigationManager")]
public class NavigationManager : ScriptableObject
{
    public enum SceneName
    {
        MainMenuScene,
        HomeScene,
        LoadScene,
        MatchScene,
        NewGameScene,
        PlayerProfileScene
    }

    List<SceneName> sceneBackHistory = new List<SceneName>();

    public void LaunchScene(SceneName scene, GameScene currentScene, bool backEnabled)
    {
        Debug.Log("LAUNCHSCENE");
        currentScene.StartCoroutine(GoToScene(scene));
        currentScene.TransitionOut();
        if (backEnabled)
        {
            sceneBackHistory.Add(currentScene.sceneName);
        }
    }

    public void Back(GameScene currentScene)
    {
        Debug.Log("Back");
        if (sceneBackHistory.Count > 0)
        {
            currentScene.StartCoroutine(GoToScene(sceneBackHistory[sceneBackHistory.Count - 1]));
            currentScene.TransitionOut();
            sceneBackHistory.RemoveAt(sceneBackHistory.Count - 1);
        }else{
            Debug.Log("There is no Scene to back to");
        }
    }
    IEnumerator GoToScene(SceneName scene)
    {
        yield return new WaitForSeconds(0.25f);
        Debug.Log("GO TO SCENE : " + scene.ToString());
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene.ToString());

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
