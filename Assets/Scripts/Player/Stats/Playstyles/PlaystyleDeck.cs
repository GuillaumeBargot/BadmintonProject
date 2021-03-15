using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlaystyleDeck
{
    private List<Playstyle> playstyles;

    //Default Playstyle deck for now
    public PlaystyleDeck(){
        playstyles = new List<Playstyle>();
        AddPlaystyle(PlaystyleHelper.NAME.NEUTRAL);
        AddPlaystyle(PlaystyleHelper.NAME.AGGRESSIVE_SMASHING);
        AddPlaystyle(PlaystyleHelper.NAME.LONG_SHOTS);
        AddPlaystyle(PlaystyleHelper.NAME.RUSHES);
    }

    public PlaystyleDeck(List<string> ids){
        playstyles = new List<Playstyle>();
        for(int i = 0; i < ids.Count; i++){
            AddPlaystyle(ids[i]);
        }
    }

    public void AddPlaystyle(PlaystyleHelper.NAME playstyleName){
        playstyles.Add(PlaystyleHelper.GetPlaystyle(playstyleName));
    }

    public void AddPlaystyle(string id){
        playstyles.Add(PlaystyleHelper.GetPlaystyle(id));
    }

    public List<string> ToStringList(){
        List<string> toReturn = new List<string>();
        for(int i = 0; i < playstyles.Count; i++){
            toReturn.Add(playstyles[i].id);
        }
        return toReturn;
    }
}
