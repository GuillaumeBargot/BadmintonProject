using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerProfileScene : GameScene
{
    [SerializeField]
    private TextMeshProUGUI playerNameTxt;

    [SerializeField]
    private TextMeshProUGUI[] playerStatValuesTxt;

    protected override void Awake() {
        base.Awake();
        playerNameTxt.text = SaveData.current.playerSave.name;
        SetPlayerStats();
    }

    private void SetPlayerStats(){
        PlayerStats stats = SaveData.current.playerSave.playerStats;
        playerStatValuesTxt[0].text = stats.Strength.ToString();
        playerStatValuesTxt[1].text = stats.Speed.ToString();
        playerStatValuesTxt[2].text = stats.Reflexes.ToString();
        playerStatValuesTxt[3].text = stats.Intelligence.ToString();
        playerStatValuesTxt[4].text = stats.Dexterity.ToString();
        playerStatValuesTxt[5].text = stats.Endurance.ToString();
    }
}
