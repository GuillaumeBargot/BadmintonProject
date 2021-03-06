﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using GameEngine;

public partial class ChanceDisc
{

    // ----------------------------------------------------------------------------------------------
    //                                      EMPTY TO 0
    // ----------------------------------------------------------------------------------------------
    private Tween AnimateTo0(){
        return DOTween.To(x => failDisc.AngRadiansEnd = x, failDisc.AngRadiansEnd, START_VAR, animationDuration).OnUpdate(()=>UpdateForReset()).SetEase(Ease.InOutCubic);
    }

    private void UpdateForReset(){
        float commonAngle = failDisc.AngRadiansEnd;
        if(commonAngle < failDisc.AngRadiansStart){
            failDisc.AngRadiansStart = commonAngle;
            normalDisc.AngRadiansEnd = commonAngle;
            if(commonAngle < normalDisc.AngRadiansStart){
                normalDisc.AngRadiansStart = commonAngle;
                critDisc.AngRadiansEnd = commonAngle;
            }
        }
    }



    // ----------------------------------------------------------------------------------------------
    //                                      FILL FROM 0
    // ----------------------------------------------------------------------------------------------


    private void FillToChance(ShotResultProbabilities resultProbabilities){
        DOTween.To(x => failDisc.AngRadiansEnd = x, failDisc.AngRadiansEnd, END_VAR, animationDuration).OnUpdate(()=>UpdateForFill(resultProbabilities)).SetEase(Ease.InOutCubic);
    }

    private void UpdateForFill(ShotResultProbabilities resultProbabilities){
        float commonAngle = failDisc.AngRadiansEnd;
        float endCrit = START_VAR + Maths.GetRadForPercentage(resultProbabilities.Crit);
        float endNormal = endCrit + Maths.GetRadForPercentage(resultProbabilities.Normal);
        if(commonAngle <= endNormal){
            failDisc.AngRadiansStart = commonAngle;
            normalDisc.AngRadiansEnd = commonAngle;
            if(commonAngle <= endCrit){
                normalDisc.AngRadiansStart = commonAngle;
                critDisc.AngRadiansEnd = commonAngle;
            }else{
                normalDisc.AngRadiansStart = endCrit;
                critDisc.AngRadiansEnd = endCrit;
            }
        }else{
            //Rectifying the angles
            failDisc.AngRadiansStart = endNormal;
            normalDisc.AngRadiansEnd = endNormal;
        }
    }

    // ----------------------------------------------------------------------------------------------
    //                                      CHANCE TO CHANCE
    // ----------------------------------------------------------------------------------------------

    private void AnimateToChance(ShotResultProbabilities resultProbabilities){
        float endCritFrom = critDisc.AngRadiansEnd;
        float endNormalFrom = normalDisc.AngRadiansEnd;

        float endCritTo = START_VAR + Maths.GetRadForPercentage(resultProbabilities.Crit);
        float endNormalTo = endCritTo + Maths.GetRadForPercentage(resultProbabilities.Normal);

        DOTween.To(x=>critDisc.AngRadiansEnd = x, endCritFrom, endCritTo, animationDuration).SetEase(Ease.InOutCubic); 
        DOTween.To(x=>normalDisc.AngRadiansStart = x, endCritFrom, endCritTo, animationDuration).SetEase(Ease.InOutCubic); 
        DOTween.To(x=>normalDisc.AngRadiansEnd = x, endNormalFrom, endNormalTo, animationDuration).SetEase(Ease.InOutCubic); 
        DOTween.To(x=>failDisc.AngRadiansStart = x, endNormalFrom, endNormalTo, animationDuration).SetEase(Ease.InOutCubic); 
    }

    // ----------------------------------------------------------------------------------------------
    //                                      ARROW
    // ----------------------------------------------------------------------------------------------

    private void TurnArrow(float randomNumber){
        float finalAngle = Maths.GetAngForPercentage(randomNumber) + 90 + 360;
        Vector3 finalVector = new Vector3(0,0,finalAngle);
        arrow.transform.DORotate(finalVector,animationDuration, RotateMode.FastBeyond360).SetEase(Ease.InOutCubic);
    }
}
