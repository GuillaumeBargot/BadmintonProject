using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlaystyleHelper 
{
    //The enum here MUST be exactly the same as the ID you put inside your Playstyle Scriptable Objects
    public enum NAME{
        NEUTRAL,
        AGGRESSIVE_SMASHING,
        LONG_SHOTS,
        RUSHES,
        SHORT_ATTACKS
    }

    public static Playstyle GetPlaystyle(NAME name){
        return ScriptableObjectHelper.GetPlaystyleWithId(name.ToString());
    }
}
