using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class DrillSelection : MonoBehaviour
{
    [SerializeField]
    Image selectionImage;

    [SerializeField]
    TextMeshProUGUI title;

    [SerializeField]
    TextMeshProUGUI[] effects;

    private string id;
    private UnityAction<string> onSelectedAction;


    public void Init(string drillId, UnityAction<string> onSelected){
        id = drillId;
        SetTitle();
        this.onSelectedAction = onSelected;
    }
    public void Select(){
        selectionImage.enabled = true;
    }

    public void Unselect(){
        selectionImage.enabled = false;
    }

    private void SetTitle(){
        title.text = id;
    }

    private void SetEffects(string[] title, float[] numbers){
        for(int i = 0; i < 3; i ++){
            if(title.Length>i){
                effects[i].gameObject.SetActive(true);
                effects[i].text = title[i] + ": " + numbers;
            }
        }
    }

    public void OnClick(){
        onSelectedAction.Invoke(id);
    }

    public string GetID(){
        return id;
    }
}
