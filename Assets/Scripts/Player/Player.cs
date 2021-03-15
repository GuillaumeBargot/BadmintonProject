using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEngine;
using UnityEditor;

public class Player
{
    public string name = "prout";
    public PlayerStats stats;
    public ShotCoordProbabilities shotCoordProbabilities;
    public ModifierList modifierList;

    //------------------------------------- PLAYSTYLES ---------------------------------
    public PlaystyleDeck playstyleDeck;
    public EquippedPlaystyles equippedPlaystyles;

    public Player(){
        name = "Jean Valjean";
        stats = new PlayerStats();
        shotCoordProbabilities = new ShotCoordProbabilities();
        modifierList = new ModifierList();
        playstyleDeck = new PlaystyleDeck();
        equippedPlaystyles = new EquippedPlaystyles();
    }

    public Player(string name){
        this.name = name;
        stats = new PlayerStats();
        shotCoordProbabilities = new ShotCoordProbabilities();
        modifierList = new ModifierList();
        playstyleDeck = new PlaystyleDeck();
        equippedPlaystyles = new EquippedPlaystyles();
    }

    public Player(PlayerSave save){
        this.name = save.name;
        this.stats = save.playerStats;
        this.shotCoordProbabilities = new ShotCoordProbabilities(save.shotCoordProbabilities);
        this.modifierList = save.modifierList;
        playstyleDeck = new PlaystyleDeck(save.playstyleDeckIDs);
        equippedPlaystyles = new EquippedPlaystyles(save.equippedPlaystylesIDs);
    }
}
