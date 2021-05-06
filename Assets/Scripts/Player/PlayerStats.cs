using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    //Placeholder
    private float strength;
    public int Strength{
        get{
            return (int)strength;
        }
    }
    private float speed;
    public int Speed{
        get{
            return (int)speed;
        }
    }
    private float reflexes;
    public int Reflexes{
        get{
            return (int)reflexes;
        }
    }
    private float intelligence;
    public int Intelligence{
        get{
            return (int)intelligence;
        }
    }
    private float dexterity;
    public int Dexterity{
        get{
            return (int)dexterity;
        }
    }
    private float endurance;
    public int Endurance{
        get{
            return (int)endurance;
        }
    }

    public PlayerStats(){
        strength = 1f;
        speed = 1f;
        reflexes = 1f;
        intelligence = 1f;
        dexterity = 1f;
        endurance = 1f;
    }

    public PlayerStats(int meanLvl){
        strength = meanLvl;
        speed = meanLvl;
        reflexes = meanLvl;
        intelligence = meanLvl;
        dexterity = meanLvl;
        endurance = meanLvl;
    }

    public void ImproveStrength(float improvement){
        strength+=improvement;
    }

    public void ImproveSpeed(float improvement){
        speed+=improvement;
    }

    public void ImproveDexterity(float improvement){
        dexterity+=improvement;
    }

    public void ImproveReflexes(float improvement){
        reflexes+=improvement;
    }

    public void ImproveIntelligence(float improvement){
        intelligence+=improvement;
    }

    public void ImproveEndurance(float improvement){
        endurance+=improvement;
    }


}
