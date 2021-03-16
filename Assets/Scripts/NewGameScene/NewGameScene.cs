using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NewGameScene : GameScene{
    
    [SerializeField]
    PopupSystem popupSystem;

    [SerializeField]
    CoachNamePopup coachNamePopupPrefab;

    [SerializeField]
    NewSaveSlots newSaveSlots;

    public void OnButtonClicked(){

        CoachNamePopup popup = popupSystem.InstantiatePopup<CoachNamePopup>(coachNamePopupPrefab);
        popup.SetSelectedSlot(newSaveSlots.GetSelectedSlot());
        popup.SetLaunchSceneMethod(LaunchHome);
    }

    public void LaunchHome(){
        navigationManager.LaunchScene(NavigationManager.SceneName.HomeScene,this,false);
    }

}
