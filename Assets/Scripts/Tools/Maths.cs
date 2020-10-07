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


    // ----------------------------------------------------------------------------------------------
    //                                      COORDINATES (3x3)
    // ----------------------------------------------------------------------------------------------

    public static int GetIndexForCoord((int, int) coord)
    {
        return coord.Item2 * 3 + coord.Item1;
    }

    public static (int, int) GetCoordForIndex(int index){
        return (index%3,index/3);
    }
}
