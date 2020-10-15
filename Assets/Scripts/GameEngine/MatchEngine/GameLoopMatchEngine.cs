using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public partial class MatchEngine
    {
        private Point currentPoint;

        public void StartGame()
        {
            Debug.Log("Match between " + player.Name() + " and " + cpu.Name() + " starting");
            score = Score.CreateBO3Match();
            StartCoroutine(PlayMatch());
        }

        public IEnumerator PlayMatch()
        {
            while (!score.CheckIfEndOfMatch())
            {
                yield return StartCoroutine(PointCoroutine());
                ProcessFinishedPoint();
                yield return new WaitForSeconds(1);
            }
            yield return null;
        }

        public IEnumerator PointCoroutine()
        {
            currentPoint = new Point(score, pointHistory);
            PositionTwoPlayersBeforeServe(currentPoint.currentPlayerServing, currentPoint.GetServingPositions(score));
            //currentShot = CreateShot(GetPlayer(playerServing));
            //currentPlayerShooting = playerServing;
           // bool isServing = true;
            while (!currentPoint.pointOver)
            {

                while (isPaused)
                {
                    yield return null;
                }

                currentPoint.NewShotIfNotServe();

                ComputeShot();
                ProcessFinishedShot();
                yield return new WaitForSeconds(currentPoint.currentShot.shotTime);
            }
            yield return null;
        }

        public void ComputeShot()
        {
            
            currentPoint.ComputeCurrentShot();

            PlayerMatchInstance currentPMI = MatchEngine.Instance.GetPlayer(currentPoint.currentPlayerShooting);
            switch (currentPoint.currentShot.shotResult)
            {
                case ShotResult.CRIT:
                    Debug.Log(currentPMI.Name() + " crits  a " + Shot.GetShotTypeName(currentPoint.currentShot.type) + " @" + currentPoint.currentShot.to.Coord + "!");
                    //score.ScoreFor(currentPoint.currentPlayerShooting);
                    currentPoint.advantage.AddAdvantage(currentPoint.currentPlayerShooting);
                    UpdateAdvantageUI(currentPoint.advantage);
                    //FieldCritResult(currentPoint.currentPlayerShooting, currentPoint.currentShot.shotCoord.Get());
                    FieldShot(currentPoint.currentPlayerShooting, currentPoint.currentShot.from, currentPoint.currentShot.to, currentPoint.currentShot.type, currentPoint.currentShot.shotTime);
                    CritMessage(currentPoint.currentPlayerShooting);
                    //RefreshScoreRecap();
                    //currentPoint.pointOver = true;
                    break;
                case ShotResult.FAIL:
                    Debug.Log(currentPMI.Name() + " fails a " + Shot.GetShotTypeName(currentPoint.currentShot.type) + " @" + currentPoint.currentShot.to.Coord + "!");
                    score.ScoreAgainst(currentPoint.currentPlayerShooting);
                    //FieldFailResult(currentPoint.currentPlayerShooting, currentPoint.currentShot.shotCoord.Get());
                    FieldShot(currentPoint.currentPlayerShooting, currentPoint.currentShot.from, currentPoint.currentShot.to,currentPoint.currentShot.type, currentPoint.currentShot.shotTime);
                    RefreshScoreRecap();
                    currentPoint.pointOver = true;
                    break;
                default:
                    FieldShot(currentPoint.currentPlayerShooting, currentPoint.currentShot.from, currentPoint.currentShot.to,currentPoint.currentShot.type, currentPoint.currentShot.shotTime);
                    Debug.Log(currentPMI.Name() + " returns a " + Shot.GetShotTypeName(currentPoint.currentShot.type) + " @" + currentPoint.currentShot.to.Coord + "!");
                    break;
            }
        }


        private void ProcessFinishedShot()
        {
            //Do something after the end of the shot. 
            currentPoint.ProcessFinishedShot();
        }
        private void ProcessFinishedPoint()
        {
            //Do something after the end of the point. Like store the point in the point history
            pointHistory.AddHistoryPoint(currentPoint.GetHistoryPoint());
            ResetAdvantageUI();
        }
    }

}
