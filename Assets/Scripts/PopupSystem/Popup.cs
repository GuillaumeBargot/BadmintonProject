using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [SerializeField]
    private Button closeButton;

    private PopupSystem parentPopupSystem;


    private void Start() {
        closeButton.onClick.AddListener(() => {ClosePopup();});
    }

    public void SetParentPopupSystem(PopupSystem parentPopupSystem){
        this.parentPopupSystem = parentPopupSystem;
    }

    private void ClosePopup(){
        parentPopupSystem.ClosePopup(this);
    }
}
