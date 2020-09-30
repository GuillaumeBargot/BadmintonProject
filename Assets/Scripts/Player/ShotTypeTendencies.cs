using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEngine;
using System.Linq;
public class ShotTypeTendencies
{
    private float[] tendencies;

    public ShotTypeTendencies(){
        tendencies = new float[ShotType.SHOT_NUMBER];
        SetDefaultTendencies();
    }

    public ShotType.Type GetShot(){
        if(tendencies.Sum()!=100.0f){
            return ShotType.Type.LONG;
        }else{
            int index = Maths.RandWithPercentages(tendencies);
            return (ShotType.Type)index;
        }
    }

    private void SetDefaultTendencies(){
        SetTendencies(new float[]{40,20,10,30});
    }

    private void SetTendencies(float[] tendencies){
        if(tendencies.Sum()==100.0f){
            this.tendencies = tendencies;
        }
    }
}
