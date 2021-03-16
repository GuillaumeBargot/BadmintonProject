using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameScene : GameScene
{
    [SerializeField]
    PopupSystem popupSystem;

    [SerializeField]
    DeleteSavePopup deleteSavePopupPrefab;

    [SerializeField]
    LoadGameSlots loadGameSlots;

    void Start() {
        loadGameSlots.SetOnDeleteClickAction(OnDeleteClick);
        loadGameSlots.SetLaunchAction(LaunchHome);
    }
    public void OnDeleteClick(int nb){
        DeleteSavePopup deleteSavePopup = popupSystem.InstantiatePopup<DeleteSavePopup>(deleteSavePopupPrefab);
        deleteSavePopup.Setup(nb, ()=>Refresh());
    }

    public void LaunchHome(){
        navigationManager.LaunchScene(NavigationManager.SceneName.HomeScene, this, false);
    }

    public void Refresh(){
        loadGameSlots.Refresh();
    }
}
