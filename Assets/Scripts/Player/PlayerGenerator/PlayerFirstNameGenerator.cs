using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerFirstNameGenerator {
    static string[] firstNameList = null;

    private static void GenerateFirstNameList(){
        firstNameList = System.IO.File.ReadAllLines(@"Assets/Resources/JSON/firstnames.txt");
        Debug.Log(firstNameList[0] + " / " + firstNameList[1] + " / ...");
        Debug.Log("First Names Size");
    }

    public static string GetFirstName(){
        if(firstNameList==null){
            GenerateFirstNameList();
        }
        int index = Random.Range(0,firstNameList.Length-1);
        return firstNameList[index];
    }
}
