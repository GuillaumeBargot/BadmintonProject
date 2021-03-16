using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameScene : MonoBehaviour
{
    [SerializeField]
    private Image transitionPanel;

    [SerializeField]
    private Button backButton;

    [SerializeField]
    protected NavigationManager navigationManager;

    public NavigationManager.SceneName sceneName;

    protected virtual void Awake() {
        transitionPanel.color = new Color(0,0,0,255);
        TransitionIn();
        if(backButton!=null){
            backButton.onClick.AddListener(()=>navigationManager.Back(this));
        }
    }

    protected void TransitionIn(){
        transitionPanel.CrossFadeAlpha(0,0.25f,false);
    }

    public void TransitionOut(){
        transitionPanel.CrossFadeAlpha(1,0.25f,false);
    }
}
