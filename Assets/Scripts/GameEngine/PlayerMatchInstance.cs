using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEngine;
public class PlayerMatchInstance 
{
    //You will use function here to communicate between the two players

    //This is to know the stats/the behaviour of the player concerned.
    Player player;

    public PlayerMatchInstance(){
        player = new Player();
    }

    public PlayerMatchInstance(string name){
        player = new Player(name);
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
    public int Vision(){
        return player.stats.vision;
    }

    public int Dexterity(){
        return player.stats.dexterity;
    }

    public int Stamina(){
        return player.stats.stamina;
    }

    public ShotTypeProbabilities ShotTypeProbabilities(){
        return player.shotTypeProbabilities;
    }

    public ShotCoordProbabilities ShotCoordTendencies(){
        return player.shotCoordProbabilities;
    }

    

}
