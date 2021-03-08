using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NewSaveSlots : MonoBehaviour
{
    [SerializeField]
    Button save1Btn;

    [SerializeField]
    TextMeshProUGUI save1Txt;

    [SerializeField]
    Button save2Btn;

    [SerializeField]
    TextMeshProUGUI save2Txt;

    [SerializeField]
    Button save3Btn;

    [SerializeField]
    TextMeshProUGUI save3Txt;

    [SerializeField]
    TextMeshProUGUI messageTxt;

    [SerializeField]
    Button validateBtn;

    [SerializeField]
    Image arrow1;

    [SerializeField]
    Image arrow2;

    [SerializeField]
    Image arrow3;

    [SerializeField]
    SaveManager saveManager;
    private int currentSaveSelected = -1;

    private bool[] savesExist;

    private void Awake()
    {
        savesExist = new bool[3];
        LoadSnapshotsIntoButtons();
    }

    private void LoadSnapshotsIntoButtons()
    {
        //Button 1:
        Snapshot snapshot1 = (Snapshot)SerializationManager.LoadSnapshot(0);
        if (snapshot1 == null)
        {
            DeclareButtonEmpty(save1Btn, save1Txt);
            savesExist[0] = false;
        }
        else
        {
            LoadButton(save1Btn, save1Txt, snapshot1);
            savesExist[0] = true;
        }

        //Button 1:
        Snapshot snapshot2 = (Snapshot)SerializationManager.LoadSnapshot(1);
        if (snapshot2 == null)
        {
            DeclareButtonEmpty(save2Btn, save2Txt);
            savesExist[1] = false;
        }
        else
        {
            LoadButton(save2Btn, save2Txt, snapshot2);
            savesExist[1] = true;
        }

        //Button 1:
        Snapshot snapshot3 = (Snapshot)SerializationManager.LoadSnapshot(2);
        if (snapshot3 == null)
        {
            DeclareButtonEmpty(save3Btn, save3Txt);
            savesExist[2] = false;
        }
        else
        {
            LoadButton(save3Btn, save3Txt, snapshot3);
            savesExist[2] = true;
        }
    }

    private void DeclareButtonEmpty(Button button, TextMeshProUGUI text)
    {
        text.text = "--EMPTY--";
    }

    private void LoadButton(Button button, TextMeshProUGUI text, Snapshot snapshot)
    {
        text.text = "Coach: " + snapshot.coachName;
    }

    public void OnSlotClick(int slotNumber)
    {
        PutArrowAt(slotNumber);
        ChangeMessage(slotNumber);
        currentSaveSelected = slotNumber;
    }

    private void PutArrowAt(int slotNumber)
    {
        switch (slotNumber)
        {
            case 0:
                arrow1.gameObject.SetActive(true);
                arrow2.gameObject.SetActive(false);
                arrow3.gameObject.SetActive(false);
                break;
            case 1:
                arrow1.gameObject.SetActive(false);
                arrow2.gameObject.SetActive(true);
                arrow3.gameObject.SetActive(false);
                break;
            case 2:
                arrow1.gameObject.SetActive(false);
                arrow2.gameObject.SetActive(false);
                arrow3.gameObject.SetActive(true);
                break;
            default:
                arrow1.gameObject.SetActive(false);
                arrow2.gameObject.SetActive(false);
                arrow3.gameObject.SetActive(false);
                break;
        }
    }

    private void ChangeMessage(int slotNumber){
        messageTxt.text = (savesExist[slotNumber]?"Write over existing save?":"Create new save?");
    }

    public void OnYesBtnClicked(){
        saveManager.OnSave(currentSaveSelected);
    }

    public int GetSelectedSlot(){
        return currentSaveSelected;
    }
}
