using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[SerializeField]
[Serializable]
public class Modifier {
    [SerializeField]
    public ModifierName modifierName;
    [SerializeField]
    public float modifierValue;

    public Modifier(ModifierName modifierName, float modifierValue){
        this.modifierName = modifierName;
        this.modifierValue = modifierValue;
    }
}
