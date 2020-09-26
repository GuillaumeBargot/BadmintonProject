using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
