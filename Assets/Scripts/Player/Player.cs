using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEngine;

public class Player
{
    public string name = "prout";

    public Sex sex;
    public PlayerStats stats;

    public ShotTypeProbabilities shotTypeProbabilities; 
    public ShotCoordProbabilities shotCoordProbabilities;

    public Player(){
        name = "Jean Valjean";
        sex = Sex.MALE;
        stats = new PlayerStats();
        shotTypeProbabilities = new ShotTypeProbabilities();
        shotCoordProbabilities = new ShotCoordProbabilities();
    }

    public Player(string name){
        this.name = name;
        sex = Sex.MALE;
        stats = new PlayerStats();
        shotTypeProbabilities = new ShotTypeProbabilities();
        shotCoordProbabilities = new ShotCoordProbabilities();
        Debug.Log("Player created, shoot coord tendencies: " );
        shotCoordProbabilities.Log();
    }
}
