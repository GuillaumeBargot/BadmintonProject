using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameEngine;
using DG.Tweening;
public class TopInformationBar : MonoBehaviour
{
    // PLAYER 1
    [SerializeField]
    private TextMeshProUGUI player1Lvl;
    [SerializeField]
    private TextMeshProUGUI player1Name;
    [SerializeField]
    private TextMeshProUGUI player1MatchScore;
    [SerializeField]
    private TextMeshProUGUI player1SetScore;
    [SerializeField]
    private TextMeshProUGUI player1STR;
    [SerializeField]
    private TextMeshProUGUI player1SPD;
    [SerializeField]
    private TextMeshProUGUI player1RFX;
    [SerializeField]
    private TextMeshProUGUI player1INT;
    [SerializeField]
    private TextMeshProUGUI player1DEX;
    [SerializeField]
    private TextMeshProUGUI player1END;

    [SerializeField]
    private Transform p1StatsRectangle;


    //PLAYER 2

    [SerializeField]
    private TextMeshProUGUI player2Lvl;
    [SerializeField]
    private TextMeshProUGUI player2Name;
    [SerializeField]
    private TextMeshProUGUI player2MatchScore;
    [SerializeField]
    private TextMeshProUGUI player2SetScore;
    [SerializeField]
    private TextMeshProUGUI player2STR;
    [SerializeField]
    private TextMeshProUGUI player2SPD;
    [SerializeField]
    private TextMeshProUGUI player2RFX;
    [SerializeField]
    private TextMeshProUGUI player2INT;
    [SerializeField]
    private TextMeshProUGUI player2DEX;
    [SerializeField]
    private TextMeshProUGUI player2END;

    [SerializeField]
    private Transform p2StatsRectangle;


    //LIKE SCORE DISPLAY
    [SerializeField]
    private MatchEventReader uIEventReader;

    private (bool, bool) pointAnimations = (false, false);
    private (bool, bool) setAnimations = (false, false);

    private Score storedScore = null;

    private void Awake() {
        uIEventReader.scoreChangedEvent+=SetScore;
    }

    private void OnDestroy() {
        uIEventReader.scoreChangedEvent-=SetScore;
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
        SetTexts(player1SetScore, player2SetScore,storedScore.GetCurrentSetScore());
    }

    private void PrintSetScore(){
        SetTexts(player1MatchScore, player2MatchScore, storedScore.GetMatchScore());
    }
    
    private void SetTexts(TextMeshProUGUI textP1, TextMeshProUGUI textP2, (int,int) score){
        textP1.text = score.Item1.ToString();
        textP2.text = score.Item2.ToString();
    }



    // INITIALIZATION:

    public void Init(PlayerMatchInstance p1, PlayerMatchInstance p2){
        player1Name.text = p1.Name();
        player2Name.text = p2.Name();

        player1STR.text = p1.Strength().ToString();
        player1SPD.text = p1.Speed().ToString();
        player1RFX.text = p1.Reflexes().ToString();
        player1INT.text = p1.Intelligence().ToString();
        player1DEX.text = p1.Dexterity().ToString();
        player1END.text = p1.Endurance().ToString();
        
        player2STR.text = p2.Strength().ToString();
        player2SPD.text = p2.Speed().ToString();
        player2RFX.text = p2.Reflexes().ToString();
        player2INT.text = p2.Intelligence().ToString();
        player2DEX.text = p2.Dexterity().ToString();
        player2END.text = p2.Endurance().ToString();

        float sumP1 = (float)(p1.Strength() + p1.Speed() + p1.Reflexes() + p1.Intelligence() + p1.Dexterity() + p1.Endurance());
        float sumP2 = (float)(p2.Strength() + p2.Speed() + p2.Reflexes() + p2.Intelligence() + p2.Dexterity() + p2.Endurance());

        float meanP1 = sumP1/6.0f;
        float meanP2 = sumP2/6.0f;

        player1Lvl.text = meanP1.ToString();
        player2Lvl.text = meanP2.ToString();
    }


    private void ScaleDownP1Stats(){
        p1StatsRectangle.DOScaleY(0,0.3f);
    }

    private void ScaleUpP1Stats(){
        p1StatsRectangle.DOScaleY(1,0.3f);
    }
    
    private void ScaleDownP2Stats(){
        p2StatsRectangle.DOScaleY(0,0.3f);
    }

    private void ScaleUpP2Stats(){
        p2StatsRectangle.DOScaleY(1,0.3f);
    }

    public void OnP1LvlClick(){
        if(p1StatsRectangle.localScale.y>0f){
            ScaleDownP1Stats();
        }else{
            ScaleUpP1Stats();
        }
    }

    public void OnP2LvlClick(){
        if(p2StatsRectangle.localScale.y>0f){
            ScaleDownP2Stats();
        }else{
            ScaleUpP2Stats();
        }
    }

}
