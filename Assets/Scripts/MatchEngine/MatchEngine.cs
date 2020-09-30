using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public class MatchEngine : MonoBehaviour
    {
        PlayerMatchInstance player1;

        PlayerMatchInstance player2;

        Score score;

        [SerializeField]
        ScoreDisplay scoreDisplay;

        [SerializeField]
        Field field;

        private int playerServing = 0;

        void Awake()
        {
            player1 = new PlayerMatchInstance("Jean");
            player2 = new PlayerMatchInstance("Edouard");
            StartCoroutine(StartMatch());
        }

        public IEnumerator StartMatch()
        {
            Debug.Log("Match between " + player1.Name() + " and " + player2.Name() + " starting");
            score = Score.CreateBO3Match();
            while (!score.CheckIfEndOfMatch())
            {
                yield return new WaitForSeconds(1);
                NewServe();
            }
            yield return null;
        }

        public void ComputeShot(Shot shot, int playerShooting)
        {
            shot.ComputeShot();
            switch (shot.shotResult)
            {
                case ShotResult.CRIT:
                    Debug.Log(GetPlayer(playerShooting).Name() + " crits  a " + ShotType.GetName(shot.type) + " @"+shot.shotCoord.Get() +"!");
                    score.ScoreFor(playerShooting);
                    FieldCritResult(playerShooting, shot.shotCoord.Get());
                    RefreshScoreRecap();
                    break;
                case ShotResult.FAIL:
                    Debug.Log(GetPlayer(playerShooting).Name() + " fails a " + ShotType.GetName(shot.type) + " @"+shot.shotCoord.Get() +"!");
                    score.ScoreAgainst(playerShooting);
                    FieldFailResult(playerShooting, shot.shotCoord.Get());
                    RefreshScoreRecap();
                    break;
                default:
                    Debug.Log(GetPlayer(playerShooting).Name() + " returns a " + ShotType.GetName(shot.type) + " @"+shot.shotCoord.Get() +"!");
                    NewShot(shot, OtherPlayer(playerShooting));
                    break;
            }
        }

        private int OtherPlayer(int player)
        {
            return player == 0 ? 1 : 0;
        }

        public void NewServe()
        {
            playerServing = OtherPlayer(playerServing);
            Shot shot = CreateShot(GetPlayer(playerServing));
            ComputeShot(shot, playerServing);
        }

        public void NewShot(Shot previousShot, int playerShooting)
        {
            Shot shot = CreateShot(GetPlayer(playerShooting));
            ComputeShot(shot, playerShooting);
        }

        public PlayerMatchInstance GetPlayer(int playerID)
        {
            return (playerID == 0) ? player1 : player2;
        }

        public Shot CreateShot(PlayerMatchInstance player)
        {
            return new Shot(player);
        }

        private void RefreshScoreRecap(){
            score.LogScore();
            scoreDisplay.SetScoreRecap(score.GetScoreRecap());
        }

        private void FieldCritResult(int playerShooting, (int, int) coord){
            field.DoARandomGreen(OtherPlayer(playerShooting));
        }

        private void FieldFailResult(int playerShooting, (int, int) coord){
            field.DoARandomGreen(playerShooting);
        }
    }
}
