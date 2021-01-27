using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EffectsZone : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI title;

    [SerializeField]
    private Transform effectsList;

    [SerializeField]
    private EffectRow effectRowPrefab;

    private List<EffectRow> effectRows;

    private void Awake() {
        effectRows = new List<EffectRow>();
    }
    public void ChangePlaystyle(Playstyle playstyle){
        title.SetText(playstyle.id);
        ChangeEffectsList(playstyle.modifiers);
    }

    public void ChangeEffectsList(ModifierList modifierList){
        //First, check the current number of childs of the effectslist to know if you want to add/delete some
        ChangeEffectsListSize(modifierList);
        for(int i = 0; i < modifierList.List.Length; i++){
            effectRows[i].SetText(modifierList.List[i].modifierName +  " at " + modifierList.List[i].modifierValue);
        }
    }

    private void ChangeEffectsListSize(ModifierList modifierList){
        while(modifierList.Size() != effectRows.Count){
            if(modifierList.Size()>effectRows.Count){
                CreateNewEffectRow();
            }else{
                DeleteLastEffectRow();
            }
        }
    }

    private void CreateNewEffectRow(){
        EffectRow nuevoEffectRow = Instantiate(effectRowPrefab, Vector3.zero, Quaternion.identity, effectsList);
        effectRows.Add(nuevoEffectRow);
    }

    private void DeleteLastEffectRow(){
        if(effectRows.Count==0) return;
        Destroy(effectRows[effectRows.Count-1].gameObject);
        effectRows.RemoveAt(effectRows.Count-1);
    }
}
