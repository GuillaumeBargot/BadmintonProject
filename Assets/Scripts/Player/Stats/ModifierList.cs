using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ModifierList {
    [SerializeField]
    private Modifier[] list;

    public ModifierList(){
        list = new Modifier[0];
    }

    public ModifierList(ModifierList otherList){
        this.list = otherList.list;
    }

    //Public getters:

    public bool HasModifier(ModifierName modifierName){
        return Array.Exists<Modifier>(list,x=>x.modifierName == modifierName);
    }
    public float GetModifier(ModifierName modifierName){
        if(HasModifier(modifierName)){
            return Array.Find<Modifier>(list,x=>x.modifierName == modifierName).modifierValue;
        }
        return 0f;
    }

    public void AddValueToModifier(ModifierName modifierName, float valueAdded){
        if(HasModifier(modifierName)){
            Array.Find<Modifier>(list,x=>x.modifierName == modifierName).modifierValue += valueAdded;
        }else{
            list = list.Add<Modifier>(new Modifier(modifierName,valueAdded));
        }
    }

    public void MergeWith(ModifierList otherList){
        foreach(Modifier modifier in otherList.list){
            AddValueToModifier(modifier.modifierName,modifier.modifierValue);
        }
    }

    public void Log(){
        Debug.Log("Size: " + list.Length);
        foreach(Modifier m in list){
            Debug.Log(m.modifierName.ToString() + " : " + m.modifierValue);
        }
    }

}
