using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlaystyleHelper 
{
    //The enum here MUST be exactly the same as the ID you put inside your Playstyle Scriptable Objects
    public enum NAME{
        AGGRESSIVE_SMASHING
    }

    public static Playstyle GetPlaystyle(NAME name){
        return ScriptableObjectHelper.GetPlaystyleWithId(name.ToString());
    }
}
