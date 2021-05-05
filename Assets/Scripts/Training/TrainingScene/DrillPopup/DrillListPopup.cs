using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class DrillListPopup : Popup
{
    [SerializeField]
    Transform listParent;

    [SerializeField]
    DrillSelection drillSelectionPrefab;

    private List<DrillSelection> drillSelections;

    UnityAction<int,string> OnSelectAction;

    int selectedIndex = -1;
    int whichSlot;

    public void Init(int whichSlot, UnityAction<int,string> onQuitAction){
        this.whichSlot = whichSlot;
        this.OnSelectAction = onQuitAction;
        drillSelections = new List<DrillSelection>();
        if(SaveData.current.training!=null){
            List<string> possessedIds = SaveData.current.training.ownedDrillIds;
            for(int i = 0; i < possessedIds.Count; i++){
                DrillSelection dS = Instantiate<DrillSelection>(drillSelectionPrefab, Vector3.zero, Quaternion.identity, listParent);
                dS.Init(possessedIds[i], OnSelected);
                drillSelections.Add(dS);
            }
        }
    }

    private void OnSelected(string id){
        OnSelectAction.Invoke(whichSlot,id);
        UpdateSelection(id);
    }

    private void UpdateSelection(string id){
        foreach(DrillSelection ds in drillSelections){
            if(ds.GetID() == id){
                ds.Select();
            }else{
                ds.Unselect();
            }
        }
    }

}
