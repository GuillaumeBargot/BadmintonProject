using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameEngine;

public class DefensivePopup : Popup
{
    [SerializeField]
    private RawImage[] tileButtonImages;

    private List<int> selectedTileIndexes;


    private void Awake() {
        selectedTileIndexes = new List<int>();
        //InitializeTilesFromStrategy(MatchEngine.Instance.GetPlayer(0).GetDefensiveStrategy());
    }

    private void InitializeTilesFromStrategy(DefensiveStrategy defensiveStrategy){
        ShotCoord[] shotCoords = defensiveStrategy.DefendedCoords;
        for(int i = 0; i < 3; i ++){
            AddIndexToSelected(shotCoords[i].Index);
        }
    }

    private void OnDestroy() {
        //MatchEngine.Instance.GetPlayer(0).SetDefensiveStrategy(GenerateDefensiveStrategy());
    }

    public void OnClick(int index){
        AddTileZone(TileZoneHelper.GetZoneForTile(index));
    }

    private bool IndexAlreadySelected(int index){
        return selectedTileIndexes.Contains(index);
    }

    private void RemoveAllIndexesFromSelected(){
        selectedTileIndexes = new List<int>();
        for(int i = 0; i < 9; i++){
            if(i!=4) ColorTileWhite(i);
        }
    }

    private void AddTileZone(int[] tiles){
        if(selectedTileIndexes.Count>=3){
            RemoveAllIndexesFromSelected();
        }
        for(int i = 0; i < tiles.Length; i++){
            AddIndexToSelected(tiles[i]);
        }
    
    }

    private void AddIndexToSelected(int index){
        selectedTileIndexes.Add(index);
        ColorTileBlue(index);
    }
    
    private void ColorTileWhite(int index){
        tileButtonImages[index].color = Color.white;
    }

    private void ColorTileBlue(int index){
        tileButtonImages[index].color = Color.blue;
    }

    private DefensiveStrategy GenerateDefensiveStrategy(){
        ShotCoord[] shotCoords = GenerateShotCoords();
        return new DefensiveStrategy(shotCoords);
    }

    private ShotCoord[] GenerateShotCoords(){
        ShotCoord[] result = new ShotCoord[3];
        for(int i = 0; i < 3; i++){
            result[i] = new ShotCoord(selectedTileIndexes[i]);
        }
        return result;
    }
}
