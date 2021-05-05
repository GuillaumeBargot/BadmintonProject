using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEngine;
public class PlayerMatchInstance 
{
    //You will use function here to communicate between the two players

    //This is to know the stats/the behaviour of the player concerned.
    private string name;
    PlayerStats playerStats;
    private EquippedPlaystyles equippedPlaystyles;
    private Playstyle currentPlaystyle;
    private ModifierList playerBaseModList;
    private ModifierList matchInstanceModList;
    private ShotCoordProbabilities playerShotCoordProbabilities;
    private UsableStats usableStats;

    public PlayerMatchInstance(){
        name = PlayerFirstNameGenerator.GetFirstName();
        playerStats = new PlayerStats();
        equippedPlaystyles = new EquippedPlaystyles();
        currentPlaystyle = equippedPlaystyles.GetPlaystyle(0);
        playerBaseModList = new ModifierList();
        playerShotCoordProbabilities = new ShotCoordProbabilities();
        RefreshModListWithPlaystyle();
    }

    public PlayerMatchInstance(string name){
        this.name = name;
        playerStats = new PlayerStats();
        equippedPlaystyles = new EquippedPlaystyles();
        currentPlaystyle = equippedPlaystyles.GetPlaystyle(0);
        playerBaseModList = new ModifierList();
        playerShotCoordProbabilities = new ShotCoordProbabilities();
        RefreshModListWithPlaystyle();
    }

    public PlayerMatchInstance(PlayerSave player){
        Debug.Log("Creating PMI with PlayerSave");
        name = player.name;
        playerStats = player.playerStats;
        equippedPlaystyles = player.GetEquippedPlaystyles();
        currentPlaystyle = equippedPlaystyles.GetPlaystyle(0);
        playerBaseModList = player.modifierList;
        playerShotCoordProbabilities = player.GetShotCoordProbabilities();
        RefreshModListWithPlaystyle();
    }

    private void RefreshModListWithPlaystyle(){

        matchInstanceModList = playerBaseModList;
        matchInstanceModList.MergeWith(currentPlaystyle.modifiers);
        matchInstanceModList.Log();
        usableStats = new UsableStats(playerStats,matchInstanceModList);
    }

    public string Name(){
        return name;
    }

    public int Strength(){
        return playerStats.Strength;
    }
    public int Speed(){
        return playerStats.Speed;
    }
    public int Reflexes(){
        return playerStats.Reflexes;
    }
    public int Intelligence(){
        return playerStats.Intelligence;
    }

    public int Dexterity(){
        return playerStats.Dexterity;
    }

    public int Endurance(){
        return playerStats.Endurance;
    }
    
    public ShotCoordProbabilities ShotCoordTendencies(){
        return playerShotCoordProbabilities;
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
