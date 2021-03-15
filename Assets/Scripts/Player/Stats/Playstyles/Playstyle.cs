using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Playstyle", menuName = "Stats/Playstyle", order = 1)]
public class Playstyle : ScriptableObjectWithID
{
    
    [SerializeField]
    public ModifierList modifiers;

    [SerializeField]
    public ShotTypeProbabilities shotTypeProbabilities;
}
