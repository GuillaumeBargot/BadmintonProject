using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefensivePopup : Popup
{
    [SerializeField]
    private RawImage[] tileButtonImages;

    private List<int> selectedTileIndexes;


    private void Awake() {
        selectedTileIndexes = new List<int>();
    }

    public void OnClick(int index){
        if(IndexAlreadySelected(index)){
            RemoveIndexFromSelected(index);
        }else{
            AddIndexToSelected(index);
        }
    }

    private bool IndexAlreadySelected(int index){
        return selectedTileIndexes.Contains(index);
    }

    private void RemoveIndexFromSelected(int index){
        selectedTileIndexes.Remove(index);
        ColorTileWhite(index);
    }

    private void AddIndexToSelected(int index){
        if(selectedTileIndexes.Count>=3){
            int indexToRemove = selectedTileIndexes[0];
            RemoveIndexFromSelected(indexToRemove);
        }
        selectedTileIndexes.Add(index);
        ColorTileBlue(index);
    }
    
    private void ColorTileWhite(int index){
        tileButtonImages[index].color = Color.white;
    }

    private void ColorTileBlue(int index){
        tileButtonImages[index].color = Color.blue;
    }
}
