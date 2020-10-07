using System.Collections;
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
    private Polyline arrow;

    private const float START_VAR = Mathf.PI / 2.0f;
    private const float END_VAR = 5 * Mathf.PI / 2.0f;
    
    private float animationDuration = 0.5f;

    private void Awake()
    {
        SetChance(new ShotResultProbabilities(new float[]{15,70,15}));
    }

    public void RandomRewindAndShow(){
        RewindAndShow(ShotResultProbabilities.RandomProbabilities());
    }

    public void RandomTransitionShow(){
        TransitionShow(ShotResultProbabilities.RandomProbabilities());
    }

    public void RandomArrowAnimation(){
        TurnArrow(Maths.Rand100());
    }

    public void RewindAndShow(ShotResultProbabilities resultProbabilities){
        AnimateTo0().OnComplete(()=>
        FillToChance(resultProbabilities));
    }

    public void TransitionShow(ShotResultProbabilities resultProbabilities){
        AnimateToChance(resultProbabilities);
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
    
    private void SetChance(ShotResultProbabilities resultProbabilities)
    {
        float endCrit = START_VAR + Maths.GetRadForPercentage(resultProbabilities.Crit);
        float endNormal = endCrit + Maths.GetRadForPercentage(resultProbabilities.Normal);

        critDisc.AngRadiansStart = START_VAR;
        critDisc.AngRadiansEnd = endCrit;
        normalDisc.AngRadiansStart = endCrit;
        normalDisc.AngRadiansEnd = endNormal;
        failDisc.AngRadiansStart = endNormal;
        failDisc.AngRadiansEnd = END_VAR;
    }


}
