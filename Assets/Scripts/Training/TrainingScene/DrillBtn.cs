using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class DrillBtn : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI title;

    [SerializeField]
    TextMeshProUGUI content;

    private UnityAction clickAction;

    public void Init(string title, string content, UnityAction clickAction){
        this.title.text = title;
        RefreshContent(content);
        this.clickAction = clickAction;
    }

    public void RefreshContent(string content){
        this.content.text = content;
    }

    public void OnClick(){
        clickAction.Invoke();
    }
}
