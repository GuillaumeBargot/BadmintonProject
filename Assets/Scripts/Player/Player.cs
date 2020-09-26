using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string name = "prout";

    public Sex sex;
    public PlayerStats stats;

    public Player(){
        name = "Jean Valjean";
        sex = Sex.MALE;
        stats = new PlayerStats();
    }

    public Player(string name){
        this.name = name;
        sex = Sex.MALE;
        stats = new PlayerStats();
    }
}
