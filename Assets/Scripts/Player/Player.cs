using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string name = "prout";

    public Sex sex;
    public PlayerStats stats;

    public ShotTypeTendencies shotTypeTendencies; 
    public ShotCoordTendencies shotCoordTendencies;

    public Player(){
        name = "Jean Valjean";
        sex = Sex.MALE;
        stats = new PlayerStats();
        shotTypeTendencies = new ShotTypeTendencies();
        shotCoordTendencies = new ShotCoordTendencies();
    }

    public Player(string name){
        this.name = name;
        sex = Sex.MALE;
        stats = new PlayerStats();
        shotTypeTendencies = new ShotTypeTendencies();
        shotCoordTendencies = new ShotCoordTendencies();
        Debug.Log("Player created, shoot coord tendencies: " );
        shotCoordTendencies.Log();
    }
}
