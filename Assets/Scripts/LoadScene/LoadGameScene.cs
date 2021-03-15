using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameScene : MonoBehaviour
{
    [SerializeField]
    PopupSystem popupSystem;

    [SerializeField]
    DeleteSavePopup deleteSavePopupPrefab;

    [SerializeField]
    LoadGameSlots loadGameSlots;

    void Start() {
        loadGameSlots.SetOnDeleteClickAction(OnDeleteClick);
    }
    public void OnDeleteClick(int nb){
        DeleteSavePopup deleteSavePopup = popupSystem.InstantiatePopup<DeleteSavePopup>(deleteSavePopupPrefab);
        deleteSavePopup.Setup(nb, ()=>Refresh());
    }

    public void Refresh(){
        loadGameSlots.Refresh();
    }
}
