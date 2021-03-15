using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [SerializeField]
    private Button closeButton;

    private PopupSystem parentPopupSystem;


    protected virtual void Start() {
        closeButton.onClick.AddListener(() => {ClosePopup();});
    }

    public void SetParentPopupSystem(PopupSystem parentPopupSystem){
        this.parentPopupSystem = parentPopupSystem;
    }

    protected void ClosePopup(){
        parentPopupSystem.ClosePopup(this);
    }
}
