using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingScene : GameScene
{
    [SerializeField]
    private DrillBtn[] drillBtns;

    [SerializeField]
    PopupSystem popupSystem;

    [SerializeField]
    DrillListPopup drillListPopupPrefab;

    protected override void Awake()
    {
        base.Awake();
        RefreshDrillBtns();
    }

    private void RefreshDrillBtns()
    {
        if (SaveData.current != null && SaveData.current.training.currentTrainingSession != null)
        {
            for (int i = 0; i < 4; i++)
            {
                int drillNb = i + 1;
                drillBtns[i].Init("Drill #" + drillNb, SaveData.current.training.currentTrainingSession.GetDrillName(i), () => OnClick(i));
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                int drillNb = i + 1;
                drillBtns[i].Init("Drill #" + drillNb, "NONE", () => OnClick(i));
            }
        }
    }
    public void OnClick(int which)
    {
        DrillListPopup popup = popupSystem.InstantiatePopup<DrillListPopup>(drillListPopupPrefab);
        popup.Init(which, SetupDrill);
    }

    public void SetupDrill(int which, string id){
        SaveData.current.training.currentTrainingSession.SetupDrill(which, id);
        RefreshDrillBtns();
    }
}
