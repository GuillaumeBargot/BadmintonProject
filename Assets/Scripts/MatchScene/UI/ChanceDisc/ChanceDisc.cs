﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using DG.Tweening;
using GameEngine;

public partial class ChanceDisc : MonoBehaviour
{
    [SerializeField]
    private Disc critDisc;

    [SerializeField]
    private Disc normalDisc;

    [SerializeField]
    private Disc failDisc;

    [SerializeField]
    private Line arrow;

    private const float START_VAR = Mathf.PI / 2.0f;
    private const float END_VAR = 5 * Mathf.PI / 2.0f;
    
    private float animationDuration = 0.5f;

    private void Awake()
    {
        SetChance(new ShotChance(15,70,15));
    }

    public void RandomRewindAndShow(){
        RewindAndShow(ShotChance.RandomChance());
    }

    public void RandomTransitionShow(){
        TransitionShow(ShotChance.RandomChance());
    }

    public void RandomArrowAnimation(){
        TurnArrow(Maths.Rand100());
    }

    public void TestLongShow(){
        TransitionShow(ShotChance.GENERIC_CHANCES[Shot.LONG]);
    }

    public void TestRushShow(){
        TransitionShow(ShotChance.GENERIC_CHANCES[Shot.RUSH]);
    }

    public void TestSmashShow(){
        TransitionShow(ShotChance.GENERIC_CHANCES[Shot.SMASH]);
    }

    public void TestShortShow(){
        TransitionShow(ShotChance.GENERIC_CHANCES[Shot.SHORT]);
    }

    public void RewindAndShow(ShotChance shotChance){
        AnimateTo0().OnComplete(()=>
        FillToChance(new ShotChance(shotChance.crit,shotChance.normal,shotChance.fail)));
    }

    public void TransitionShow(ShotChance shotChance){
        AnimateToChance(new ShotChance(shotChance.crit, shotChance.normal, shotChance.fail));
    }


    //NON ANIMATED CHANGES TO THE PIE PARTS:

    private void ResetChances(bool animation)
    {
        if(!animation){
            critDisc.AngRadiansStart = START_VAR;
            critDisc.AngRadiansEnd = START_VAR;

            normalDisc.AngRadiansStart = START_VAR;
            normalDisc.AngRadiansEnd = START_VAR;

            failDisc.AngRadiansStart = START_VAR;
            failDisc.AngRadiansEnd = START_VAR;
        }else{
            AnimateTo0();
        }
    }
    
    private void SetChance(ShotChance shotChance)
    {
        float endCrit = START_VAR + Maths.GetRadForPercentage(shotChance.crit);
        float endNormal = endCrit + Maths.GetRadForPercentage(shotChance.normal);

        critDisc.AngRadiansStart = START_VAR;
        critDisc.AngRadiansEnd = endCrit;
        normalDisc.AngRadiansStart = endCrit;
        normalDisc.AngRadiansEnd = endNormal;
        failDisc.AngRadiansStart = endNormal;
        failDisc.AngRadiansEnd = END_VAR;
    }


}
