using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NewSaveSlots : GameSlots
{
    [SerializeField]
    TextMeshProUGUI messageTxt;

    [SerializeField]
    Button validateBtn;

    private void Awake()
    {
        savesExist = new bool[3];
        LoadSnapshotsIntoButtons();
    }

    public void OnSlotClick(int slotNumber)
    {
        PutArrowAt(slotNumber);
        ChangeMessage(slotNumber);
        currentSaveSelected = slotNumber;
    }

    private void ChangeMessage(int slotNumber){
        messageTxt.text = (savesExist[slotNumber]?"Write over existing save?":"Create new save?");
    }
}
