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

    public static float[] Multiply(this float[] array, float multiplicator)
        {
            for (int i = 0; i < 9; i++)
            {
                array[i] *= multiplicator;
            }
            return array;
        }

    public static float[] Multiply(this float[] array1, float[] array2){
        int length = array1.Length;
        if(length!=array2.Length){
            return array1;
        }
        float[] result = new float[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = array1[i] * array2[i];
            }

        return result;
    }
}
