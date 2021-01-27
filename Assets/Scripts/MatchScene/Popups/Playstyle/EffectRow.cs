using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EffectRow : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI effectText;

    public void SetText(string text){
        effectText.SetText(text);
    }
}
