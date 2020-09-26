using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotChance
{
    public static readonly ShotChance[] GENERIC_CHANCES = new ShotChance[]{
        new ShotChance(2,90,8),
        new ShotChance(10,75,15),
        new ShotChance(25,55,20),
        new ShotChance(25,55,20)
    };

    public float crit;
    public float normal;
    public float fail;

    public ShotChance(float critChance, float normalChance, float failChance){
        if(critChance+normalChance+failChance==100.0f){
        this.crit = critChance;
        this.normal = normalChance;
        this.fail = failChance;
        }
        else{
            CreateDefaultShotChance();
        }
    }

    private void CreateDefaultShotChance(){
        crit = 10.0f;
        normal = 80.0f;
        fail = 10.0f;
    }

    public static ShotChance RandomChance(){
        float randomFail = Random.Range(1,49);
        float randomCrit = Random.Range(1,49);
        float randomNormal = 100 - randomCrit - randomFail;
        return new ShotChance(randomCrit, randomNormal, randomFail);
    }
}
