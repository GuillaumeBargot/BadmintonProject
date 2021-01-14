using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using GameEngine;

public class ScriptableObjectHelper
{
    //Basic function that will be used by all the rest
    public static T GetScriptableObject<T>(string category, string name) where T : ScriptableObject{
        return (T)Resources.Load("ScriptableObjects/" + category + "/" + name, typeof(T));
    }

    public static T[] GetScriptableObjects<T>(string category) where T : ScriptableObject{
        return Resources.LoadAll<T>("ScriptableObjects/" + category);
    }

    public static T GetScriptableObjectWithID<T>(string category, string ID) where T : ScriptableObjectWithID{
        T[] scriptableObjectArray = GetScriptableObjects<T>(category);
        return Array.Find(scriptableObjectArray, x=>x.id==ID);
    }

    public static Playstyle GetPlaystyle(string name){
        return GetScriptableObject<Playstyle>("Playstyles",name);
    }

    public static Playstyle GetPlaystyleWithId(string ID){
        return GetScriptableObjectWithID<Playstyle>("Playstyles",ID);
    }

    public static ShotTypeProbabilities GetShotTypeProbabilitiesWithId(string ID){
        return GetScriptableObjectWithID<ShotTypeProbabilities>("ShotTypeProbabilities",ID);
    }

    
}
