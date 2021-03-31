using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEngine;

[System.Serializable]
public class PlayerSave {
    public string name;
    public PlayerStats playerStats;

    public float[] shotCoordProbabilities;

    public ModifierList modifierList;

    public List<string> playstyleDeckIDs;

    public List<string> equippedPlaystylesIDs;

    public PlayerSave(){

    }

    public PlayerSave(Player player){
        name = player.name;
        playerStats = player.stats;
        shotCoordProbabilities = player.shotCoordProbabilities.GetRawProbabilities();
        modifierList = player.modifierList;
        playstyleDeckIDs = player.playstyleDeck.ToStringList();
        equippedPlaystylesIDs = player.playstyleDeck.ToStringList();
    }

    public static PlayerSave CreateRandomCPU(){
        PlayerSave playerToReturn = new PlayerSave();
        playerToReturn.name = PlayerFirstNameGenerator.GetFirstName();
        playerToReturn.playerStats = new PlayerStats();
        playerToReturn.shotCoordProbabilities = new ShotCoordProbabilities().GetRawProbabilities();
        playerToReturn.modifierList = new ModifierList();
        playerToReturn.playstyleDeckIDs = new PlaystyleDeck().ToStringList();
        playerToReturn.equippedPlaystylesIDs = new EquippedPlaystyles().ToStringList();
        return playerToReturn;
    }

    public EquippedPlaystyles GetEquippedPlaystyles(){
        return new EquippedPlaystyles(equippedPlaystylesIDs);
    }

    public PlaystyleDeck GetPlaystyleDeck(){
        return new PlaystyleDeck(playstyleDeckIDs);
    }

    public ShotCoordProbabilities GetShotCoordProbabilities(){
        return new ShotCoordProbabilities(shotCoordProbabilities);
    }
}
