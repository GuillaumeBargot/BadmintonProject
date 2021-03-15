using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DeleteSavePopup : Popup
{
    private int saveNb;
    private UnityAction afterDeleteAction;

    [SerializeField]
    private SaveManager saveManager;
    public void Setup(int saveNb, UnityAction afterDeleteAction){
        this.saveNb = saveNb;
        this.afterDeleteAction = afterDeleteAction;
    }

    public void OnYesClick(){
        saveManager.Delete(saveNb);
        afterDeleteAction.Invoke();
        ClosePopup();
    }
}
