using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameEngine;

public class PlaystylePopup : Popup
{
    //--------------------------- PLAYSTYLE ROW ------------------------------
    [SerializeField]
    TextMeshProUGUI p1BtnText, p2BtnText, p3BtnText;

    //------------------------- EFFECTS ROW -----------------------------------
    [SerializeField]
    private EffectsZone effectsZone;

    //-------------------------- UI EVENT READER -----------------------------
    [SerializeField]
    private MatchEventReader uIEventReader;

    //------------------------- private ----------------------------------

    private PlayerMatchInstance player;

    private void Awake() {
        player = MatchEngine.Instance.GetPlayer(0);
    }

    private void Start() {
        base.Start();
        MatchEngine.Instance.Pause();
        SetPlaystyleButtons();
        RefreshEffectsZone();
    }

    private void SetPlaystyleButtons(){
        p1BtnText.SetText(player.GetEquippedPlaystyles().GetPlaystyle(0).id);
        p2BtnText.SetText(player.GetEquippedPlaystyles().GetPlaystyle(1).id);
        p3BtnText.SetText(player.GetEquippedPlaystyles().GetPlaystyle(2).id);
    }

    private void RefreshEffectsZone(){
        effectsZone.ChangePlaystyle(player.GetCurrentPlaystyle());
    }

    public void OnP1BtnClick(){
        player.SetCurrentPlaystyle(0);
        RefreshEffectsZone();
        uIEventReader.OnPlaystyleChanged(0);
    }

    public void OnP2BtnClick(){
        player.SetCurrentPlaystyle(1);
        RefreshEffectsZone();
        uIEventReader.OnPlaystyleChanged(0);
    }

    public void OnP3BtnClick(){
        player.SetCurrentPlaystyle(2);
        RefreshEffectsZone();
        uIEventReader.OnPlaystyleChanged(0);
    }

}
