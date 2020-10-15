using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using GameEngine;

public class FieldShotEase {
    private static Ease shortEase = Ease.OutCirc;
    private static Ease longEase = Ease.OutCirc;

    private static Ease smashEase = Ease.InOutExpo;
    private static Ease rushEase = Ease.OutExpo;

    public static Ease GetEaseForType(ShotType type){
        switch(type){
            case ShotType.LONG:
                return longEase;
            case ShotType.RUSH:
                return rushEase;
            case ShotType.SHORT:
                return shortEase;
            case ShotType.SMASH:
                return smashEase;
            default:
                return longEase;
        }
    
    }
}
