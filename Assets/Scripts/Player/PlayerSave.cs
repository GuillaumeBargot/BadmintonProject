using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSave {
    public string name;
    public PlayerStats playerStats;

    public float[] shotCoordProbabilities;

    public ModifierList modifierList;

    public List<string> playstyleDeckIDs;

    public List<string> equippedPlaystylesIDs;

    public PlayerSave(Player player){
        name = player.name;
        playerStats = player.stats;
        shotCoordProbabilities = player.shotCoordProbabilities.GetRawProbabilities();
        modifierList = player.modifierList;
        playstyleDeckIDs = player.playstyleDeck.ToStringList();
        equippedPlaystylesIDs = player.playstyleDeck.ToStringList();
    }
}
