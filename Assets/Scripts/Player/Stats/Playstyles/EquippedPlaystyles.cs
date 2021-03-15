using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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

    public EquippedPlaystyles(List<string> ids){
        playstyles = new Playstyle[3];
        for(int i = 0; i < 3; i++){
            playstyles[i] = PlaystyleHelper.GetPlaystyle(ids[0]);
        }
    }

    public Playstyle GetPlaystyle(int index){
        if(index<0 || index>2){
            return PlaystyleHelper.GetPlaystyle(PlaystyleHelper.NAME.NEUTRAL);
        }
        return playstyles[index];
    }

    public List<string> ToStringList(){
        List<string> toReturn = new List<string>();
        for(int i = 0; i < playstyles.Length; i++){
            toReturn.Add(playstyles[i].id);
        }
        return toReturn;
    }
}
