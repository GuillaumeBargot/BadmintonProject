using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArrayExtensions
{
    public static T[] Populate<T>(this T[] arr, T value)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = value;
        }

        return arr;
    }

    /*public static float Sum(this float[] arr){
        float sum = 0.0f;
        for(int i = 0; i < arr.Length; i++){
            sum += arr[i];
        }
        return sum;
    }*/
}
