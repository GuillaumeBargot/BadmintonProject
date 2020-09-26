using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI[] pointsTexts;

    [SerializeField]
    private TextMeshProUGUI[] setsTexts;

    private (bool, bool) pointAnimations = (false, false);
    private (bool, bool) setAnimations = (false, false);

    private ScoreRecap storedScoreRecap = null;

    public void SetPointTexts((int, int) points)
    {
        pointsTexts[0].text = points.Item1.ToString();
        pointsTexts[1].text = points.Item2.ToString();
    }

    public void SetSetTexts((int, int) sets)
    {
        setsTexts[0].text = sets.Item1.ToString();
        setsTexts[1].text = sets.Item2.ToString();
    }

    public void SetScoreRecap(ScoreRecap scoreRecap)
    {
        if (storedScoreRecap != null)
        {
            //Check if there is any difference between the two match scores:
            pointAnimations.Item1 = scoreRecap.currentSet.Item1 != storedScoreRecap.currentSet.Item1;
            pointAnimations.Item2 = scoreRecap.currentSet.Item2 != storedScoreRecap.currentSet.Item2;
            setAnimations.Item1 = scoreRecap.sets.Item1 != storedScoreRecap.sets.Item1;
            setAnimations.Item1 = scoreRecap.sets.Item2 != storedScoreRecap.sets.Item2;
        }
        storedScoreRecap = scoreRecap;
        PrintScoreRecap();
    }

    private void PrintScoreRecap(){
        PrintCurrentScore();
        PrintSetScore();
    }

    private void PrintCurrentScore(){
        SetTexts(pointsTexts,storedScoreRecap.currentSet);
    }

    private void PrintSetScore(){
        SetTexts(setsTexts, storedScoreRecap.sets);
    }
    
    private void SetTexts(TextMeshProUGUI[] texts, (int,int) score){
        if(texts.Length>=2){
            texts[0].text = score.Item1.ToString();
            texts[1].text = score.Item2.ToString();
        }
    }

}
