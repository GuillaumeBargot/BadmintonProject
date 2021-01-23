using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GameEngine;

[CustomEditor(typeof(ShotTypeProbabilities))]
[CanEditMultipleObjects]
public class ShotTypeProbabilitiesEditor : Editor 
{
    SerializedProperty id;
    SerializedProperty probabilities;
    
    void OnEnable()
    {
        id = serializedObject.FindProperty("id");
        probabilities = serializedObject.FindProperty("probabilities");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        //EditorGUILayout.PropertyField(probabilities);
        EditorGUILayout.PropertyField(id);
        //probabilities.arraySize = EditorGUILayout.IntField("Size", probabilities.arraySize);
        SerializedProperty longProp = probabilities.GetArrayElementAtIndex(0);
        EditorGUILayout.PropertyField(longProp, new GUIContent("Long Shot %"));
        SerializedProperty rushProp = probabilities.GetArrayElementAtIndex(1);
        EditorGUILayout.PropertyField(rushProp, new GUIContent("Rush %"));
        SerializedProperty shortProp = probabilities.GetArrayElementAtIndex(2);
        EditorGUILayout.PropertyField(shortProp, new GUIContent("Short Shot %"));
        SerializedProperty smashProp = probabilities.GetArrayElementAtIndex(3);
        EditorGUILayout.PropertyField(smashProp, new GUIContent("Smash %"));

        if(id.stringValue==""){
            EditorGUILayout.LabelField("(WARNING: ID missing)");
        }
        float sum = longProp.floatValue + rushProp.floatValue + shortProp.floatValue + smashProp.floatValue;
        if(sum!=100){
            EditorGUILayout.LabelField("WARNING: Sum is " + sum + " %");
        }


        serializedObject.ApplyModifiedProperties();
    }
}
