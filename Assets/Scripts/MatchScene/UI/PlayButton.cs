﻿using System.Collections;
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
    MatchEventReader eventReader;

    private void Start() {
        eventReader.pausedEvent+=OnPaused;
        eventReader.matchOver += OnMatchOver;
    }

    private void OnDestroy() {
        eventReader.pausedEvent-=OnPaused;
        eventReader.matchOver -= OnMatchOver;
    }

    public void OnClick(){
        MatchEngine.Instance.PlayOrPause();
    }

    private void OnPaused(bool paused){
        if(paused){
            OnStatePaused();
        }else{
            OnStatePlaying();
        }
    }
    public void OnStatePlaying(){
        icon.sprite = pauseBtnIcon;
    }

    public void OnStatePaused(){
        icon.sprite = playBtnIcon;
    }

    public void OnMatchOver(){
        ((Button)(this.GetComponent<Button>())).enabled = false;
    }
}
