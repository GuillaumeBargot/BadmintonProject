using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrainingResultScene : GameScene
{

    [SerializeField]
    private CalendarEventReader calendarEventReader;

    [SerializeField]
    private TextMeshProUGUI drillEffectText;

    private List<DrillEffect> drillEffects;

    private void Start() {
        InitDrillEffects();
        WriteDrillEffects();
    }
    public void OnContinueClick(){
        SaveData.current.calendar.NextMonth(calendarEventReader);
        ApplyEffects();
        navigationManager.LaunchScene(NavigationManager.SceneName.HomeScene,this,false);
    }

    public void InitDrillEffects(){
        drillEffects = SaveData.current.training.currentTrainingSession.GetDrillEffects();
    }
    private void WriteDrillEffects(){
        string fullText = "";
        foreach(DrillEffect drillEffect in drillEffects){
            fullText += drillEffect.id + " : " + drillEffect.effect + "\n"; 
        }
        drillEffectText.text = fullText;
    }

    private void ApplyEffects(){
        if(drillEffects!=null){
            foreach(DrillEffect effect in drillEffects){
                effect.Apply(ref SaveData.current.playerSave.playerStats);
            }
        }
    }
}
