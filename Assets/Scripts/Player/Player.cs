using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEngine;
using UnityEditor;

public class Player
{
    public string name = "prout";
    public PlayerStats stats;

    public ShotTypeProbabilities shotTypeProbabilities; 
    public ShotCoordProbabilities shotCoordProbabilities;
    public ModifierList modifierList;

    //------------------------------------- PLAYSTYLES ---------------------------------
    public PlaystyleDeck playstyleDeck;
    public EquippedPlaystyles equippedPlaystyles;

    public Player(){
        name = "Jean Valjean";
        stats = new PlayerStats();
        shotTypeProbabilities = new ShotTypeProbabilities();
        shotCoordProbabilities = new ShotCoordProbabilities();
        modifierList = new ModifierList();
        playstyleDeck = new PlaystyleDeck();
        equippedPlaystyles = new EquippedPlaystyles();
    }

    public Player(string name){
        this.name = name;
        stats = new PlayerStats();
        shotTypeProbabilities = new ShotTypeProbabilities();
        shotCoordProbabilities = new ShotCoordProbabilities();
        modifierList = new ModifierList();
        playstyleDeck = new PlaystyleDeck();
        equippedPlaystyles = new EquippedPlaystyles();
    }
}
