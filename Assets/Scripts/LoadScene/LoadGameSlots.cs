using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LoadGameSlots : GameSlots
{
    [SerializeField]
    TextMeshProUGUI messageTxt;

    [SerializeField]
    Button validateBtn;

    [SerializeField]
    Button deleteButton0;

    [SerializeField]
    Button deleteButton1;

    [SerializeField]
    Button deleteButton2;

    private UnityAction<int> onDeleteClick;

    private UnityAction sceneLaunchAction;

    private void Start() {
        RefreshDeleteButtons();
    }


    private void RefreshDeleteButtons(){
        deleteButton0.gameObject.SetActive(savesExist[0]);
        deleteButton1.gameObject.SetActive(savesExist[1]);
        deleteButton2.gameObject.SetActive(savesExist[2]);
    }
    public void OnSlotClick(int slotNumber)
    {
        PutArrowAt(slotNumber);
        ChangeMessage(slotNumber);
        currentSaveSelected = slotNumber;
    }

    public void OnDeleteBtnClick(int nb){
        LaunchDeleteSavePopup(nb);
    }

    private void LaunchDeleteSavePopup(int nb){
        onDeleteClick.Invoke(nb);
    }

    private void ChangeMessage(int slotNumber){
        bool exists = savesExist[slotNumber];
        messageTxt.text = (exists?"Load game ?":"No save");
        validateBtn.enabled = exists;
    }

    public void OnValidateClick(){
        saveManager.Load(currentSaveSelected);
        sceneLaunchAction.Invoke();
    }

    public void SetLaunchAction(UnityAction sceneLaunchAction){
        this.sceneLaunchAction = sceneLaunchAction;
    }

    public void SetOnDeleteClickAction(UnityAction<int> onDeleteClickAction){
        this.onDeleteClick = onDeleteClickAction;
    }

    public void Refresh(){
        LoadSnapshotsIntoButtons();
        RefreshDeleteButtons();
    }

}

