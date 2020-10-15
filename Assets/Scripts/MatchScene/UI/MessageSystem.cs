using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MessageSystem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI p1CritMessage;

    [SerializeField]
    private TextMeshProUGUI cpuCritMessage;

    public void CritMessage(int playerShooting){
        ShowCritMessage(playerShooting==0?p1CritMessage:cpuCritMessage);
    }

    private void ShowCritMessage(TextMeshProUGUI text){
        Debug.Log("SHOULD GO HERE");
        float alpha = 0;
        DOTween.To(x => alpha = x, alpha, 1, 0.5f).OnUpdate(()=>UpdateTextAlpha(text,alpha)).SetEase(Ease.InOutCubic).OnComplete(()=>HideCritMessage(text));
    }

    private void HideCritMessage(TextMeshProUGUI text){
        float alpha = 1;
        DOTween.To(x => alpha = x, alpha, 0, 0.5f).OnUpdate(()=>UpdateTextAlpha(text,alpha)).SetEase(Ease.InOutCubic);
    }

    private void UpdateTextAlpha(TextMeshProUGUI text, float alpha){
        Color color = text.color;
        color.a = alpha;
        text.color = color;
        text.ForceMeshUpdate();
    }
}
