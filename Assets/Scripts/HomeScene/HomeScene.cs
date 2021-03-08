using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HomeScene : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI coachNameText;

    private void Awake() {
        coachNameText.text = SaveData.current.profile.playerName;
    }
}
