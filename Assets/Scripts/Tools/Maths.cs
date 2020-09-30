using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class Maths
{

    // ----------------------------------------------------------------------------------------------
    //                                      ANGLES
    // ----------------------------------------------------------------------------------------------

    public static float GetRadForPercentage(float percentage){
        return Mathf.PI * (float)percentage/50;
    }

    public static float RadRelativeToFull(float angle){
        return angle / (2.0f * Mathf.PI);
    }

    public static float GetAngForPercentage(float percentage){
        return (percentage / 100f) * 360.0f;
    }

    // ----------------------------------------------------------------------------------------------
    //                                      RANDOM
    // ----------------------------------------------------------------------------------------------

    public static float Rand100(){
        return Random.Range(0f,100f);
    }

    public static int Rand9(){
        return Random.Range(0,9);
    }

    public static (int,int) RandCoord(){
        return (Random.Range(0,3),Random.Range(0,3));
    }

    public static int RandWithPercentages(float[] percentages){
        float rand = Rand100();
        float previousChancesSum = 0;
        for(int i = 0; i < percentages.Length; i ++){
            if(rand<= previousChancesSum + percentages[i]){
                return i;
            }
            previousChancesSum+=percentages[i];
        }
        return percentages.Length-1;
    }


    // ----------------------------------------------------------------------------------------------
    //                                      COORDINATES (3x3)
    // ----------------------------------------------------------------------------------------------

    public static int GetIndexForCoord((int, int) coord)
    {
        return coord.Item1 * 3 + coord.Item2;
    }

    public static (int, int) GetCoordForIndex(int index){
        return (index/3,index%3);
    }

    public static float[] MergeCoordTendencies(float[] tendencies1, float[] tendencies2){
        float[] resultingTendencies = new float[9];
        for(int i = 0; i < 9; i++){
            resultingTendencies[i] = tendencies1[i] * tendencies2[i];
        }

        float resultSum = resultingTendencies.Sum();
        float multiplicator = 100f/resultSum;

        resultingTendencies.Multiply(multiplicator);
        return resultingTendencies;
    }

    public static float[] Multiply(this float[] tendencies, float multiplicator){
        for(int i = 0; i < 9; i++){
            tendencies[i] *= multiplicator;
        }
        return tendencies;
    }
}
