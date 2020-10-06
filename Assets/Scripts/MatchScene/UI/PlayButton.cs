using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField]
    Sprite playBtnIcon;

    [SerializeField]
    Sprite pauseBtnIcon;

    [SerializeField]
    Image icon;

    [SerializeField]
    MatchEngine matchEngine;

    public void OnClick(){
        matchEngine.PlayOrPause();
    }

    public void OnStatePlaying(){
        icon.sprite = pauseBtnIcon;
    }

    public void OnStatePaused(){
        icon.sprite = playBtnIcon;
    }
}
