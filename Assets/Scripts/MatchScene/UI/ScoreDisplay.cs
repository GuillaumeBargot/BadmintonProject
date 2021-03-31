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

    [SerializeField]
    private MatchEventReader uIEventReader;

    private (bool, bool) pointAnimations = (false, false);
    private (bool, bool) setAnimations = (false, false);

    private Score storedScore = null;

    private void Start() {
        uIEventReader.scoreChangedEvent+=SetScore;
    }

    private void OnDestroy() {
        uIEventReader.scoreChangedEvent-=SetScore;
    }
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

    public void SetScore(Score score)
    {
        if (storedScore != null)
        {
            //Check if there is any difference between the two match scores:
            (int, int) currentSetScore = score.GetCurrentSetScore();
            (int, int) currentSetStoredScore = storedScore.GetCurrentSetScore();
            pointAnimations.Item1 = currentSetScore.Item1 != currentSetStoredScore.Item1;
            pointAnimations.Item2 = currentSetScore.Item2 != currentSetStoredScore.Item2;

            (int, int) matchScore = score.GetMatchScore();
            (int, int) storedMatchScore = storedScore.GetMatchScore();
            setAnimations.Item1 = matchScore.Item1 != storedMatchScore.Item1;
            setAnimations.Item1 = matchScore.Item2 != storedMatchScore.Item2;
        }
        storedScore = score;
        PrintScoreRecap();
    }

    private void PrintScoreRecap(){
        PrintCurrentScore();
        PrintSetScore();
    }

    private void PrintCurrentScore(){
        SetTexts(pointsTexts,storedScore.GetCurrentSetScore());
    }

    private void PrintSetScore(){
        SetTexts(setsTexts, storedScore.GetMatchScore());
    }
    
    private void SetTexts(TextMeshProUGUI[] texts, (int,int) score){
        if(texts.Length>=2){
            texts[0].text = score.Item1.ToString();
            texts[1].text = score.Item2.ToString();
        }
    }

}
