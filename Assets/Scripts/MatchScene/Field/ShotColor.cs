using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEngine;
public class ShotColor
{
    private static Color32 shortColor = new Color32(76,175,80,255);
    private static Color32 longColor = new Color32(63,81,181,255);

    private static Color32 smashColor = new Color32(244,67,54,255);

    private static Color32 rushColor = new Color32(255,193,7,255);

    public static Color GetColorForType(ShotType type){
        switch(type){
            case ShotType.LONG:
                return longColor;
            case ShotType.RUSH:
                return rushColor;
            case ShotType.SHORT:
                return shortColor;
            case ShotType.SMASH:
                return smashColor;
            default:
                return longColor;
        }
    
    }
}
