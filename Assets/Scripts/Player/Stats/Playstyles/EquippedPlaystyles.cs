using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedPlaystyles
{
    private Playstyle[] playstyles;

    //Default Constructor
    public EquippedPlaystyles(){
        playstyles = new Playstyle[3];
        playstyles[0] = PlaystyleHelper.GetPlaystyle(PlaystyleHelper.NAME.NEUTRAL);
        playstyles[1] = PlaystyleHelper.GetPlaystyle(PlaystyleHelper.NAME.AGGRESSIVE_SMASHING);
        playstyles[2] = PlaystyleHelper.GetPlaystyle(PlaystyleHelper.NAME.LONG_SHOTS);
    }

    public Playstyle GetPlaystyle(int index){
        if(index<0 || index>2){
            return PlaystyleHelper.GetPlaystyle(PlaystyleHelper.NAME.NEUTRAL);
        }
        return playstyles[index];
    }
}
