﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEngine;
public class PlayerMatchInstance 
{
    //You will use function here to communicate between the two players

    //This is to know the stats/the behaviour of the player concerned.
    Player player;
    private EquippedPlaystyles equippedPlaystyles;
    private Playstyle currentPlaystyle;
    private ModifierList matchInstanceModList;
    private UsableStats usableStats;

    public PlayerMatchInstance(){
        player = new Player();
        equippedPlaystyles = player.equippedPlaystyles;
        currentPlaystyle = equippedPlaystyles.GetPlaystyle(0);
        RefreshModListWithPlaystyle();
    }

    public PlayerMatchInstance(string name){
        player = new Player(name);
        equippedPlaystyles = player.equippedPlaystyles;
        currentPlaystyle = equippedPlaystyles.GetPlaystyle(0);
        RefreshModListWithPlaystyle();
    }

    private void RefreshModListWithPlaystyle(){
        matchInstanceModList = player.modifierList;
        matchInstanceModList.MergeWith(currentPlaystyle.modifiers);
        matchInstanceModList.Log();
        usableStats = new UsableStats(player.stats,matchInstanceModList);
    }

    public string Name(){
        return player.name;
    }

    public int Strength(){
        return player.stats.strength;
    }
    public int Speed(){
        return player.stats.speed;
    }
    public int Reflexes(){
        return player.stats.reflexes;
    }
    public int Intelligence(){
        return player.stats.intelligence;
    }

    public int Dexterity(){
        return player.stats.dexterity;
    }

    public int Endurance(){
        return player.stats.endurance;
    }
    
    public ShotCoordProbabilities ShotCoordTendencies(){
        return player.shotCoordProbabilities;
    }

    public Playstyle GetCurrentPlaystyle(){
        return currentPlaystyle;
    }

    public void SetCurrentPlaystyle(int equippedIndex){
        currentPlaystyle = equippedPlaystyles.GetPlaystyle(equippedIndex);
    }

    public void SetPlaystyle(Playstyle playstyle){
        this.currentPlaystyle = playstyle;
    }

    public ModifierList GetModifierList(){
        return matchInstanceModList;
    }

    public UsableStats GetUsableStats(){
        return usableStats;
    }

    public EquippedPlaystyles GetEquippedPlaystyles(){
        return equippedPlaystyles;
    }
    

}
