using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSlots : MonoBehaviour
{
    [SerializeField]
    protected Button save1Btn;

    [SerializeField]
    protected TextMeshProUGUI save1Txt;

    [SerializeField]
    protected Button save2Btn;

    [SerializeField]
    protected TextMeshProUGUI save2Txt;

    [SerializeField]
    protected Button save3Btn;

    [SerializeField]
    protected TextMeshProUGUI save3Txt;

    [SerializeField]
    protected Image arrow1;

    [SerializeField]
    protected Image arrow2;

    [SerializeField]
    protected Image arrow3;

    [SerializeField]
    protected SaveManager saveManager;
    protected int currentSaveSelected = -1;

    protected bool[] savesExist;

    private void Awake()
    {
        savesExist = new bool[3];
        LoadSnapshotsIntoButtons();
    }
    protected void LoadSnapshotsIntoButtons()
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
        text.text = "Coach: " + snapshot.coachName + "\nPlayer: " + snapshot.currentPlayerName;
    }

    protected void PutArrowAt(int slotNumber)
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

    public int GetSelectedSlot()
    {
        return currentSaveSelected;
    }
}
