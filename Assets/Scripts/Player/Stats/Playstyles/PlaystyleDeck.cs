using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void AddPlaystyle(PlaystyleHelper.NAME playstyleName){
        playstyles.Add(PlaystyleHelper.GetPlaystyle(playstyleName));
    }
}
