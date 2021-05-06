using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameEngine;

public class AdvantageBar : MonoBehaviour
{
    [SerializeField]
    private Image[] cpuAdvantages;

    [SerializeField]
    private Image[] p1Avantages;

    public void UpdateAdvantage(Advantage advantage){
        SetAdvantage(advantage.Player, advantage.Amount);
    }

    public void Reset(){
        DeactivateTheBars(cpuAdvantages);
        DeactivateTheBars(p1Avantages);
    }
    private void SetAdvantage(int recipientPlayer, int advantage){
        if(advantage<=3){
            DeactivateTheBars(recipientPlayer==0?cpuAdvantages:p1Avantages);
            ActivateTheBars(recipientPlayer==0?p1Avantages:cpuAdvantages, advantage);
        }
    }

    private void DeactivateTheBars(Image[] bars){
        for(int i = 0; i < bars.Length; i ++){
            bars[i].gameObject.SetActive(false);
        }
    }
    private void ActivateTheBars(Image[] bars, int number){
        if(number == 0) return;
        for(int i = 0; i < number; i++){
            bars[i].gameObject.SetActive(true);
        }
    }

}
