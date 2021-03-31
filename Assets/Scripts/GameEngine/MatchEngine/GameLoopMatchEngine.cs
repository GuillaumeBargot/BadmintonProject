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
            scoreManager = ScoreManager.CreateBO3Match(eventReader);
            StartCoroutine(PlayMatch());
        }

        public IEnumerator PlayMatch()
        {
            while (!scoreManager.CheckIfEndOfMatch())
            {
                yield return StartCoroutine(PointCoroutine());
                ProcessFinishedPoint();
                yield return new WaitForSeconds(0.1f); //SAME, PLS PUT IT 10x LONGER FOR NORMAL TIMING
            }
            yield return null;
        }

        public IEnumerator PointCoroutine()
        {
            currentPoint = new Point(scoreManager.Score, pointHistory);
            PositionTwoPlayersBeforeServe(currentPoint.currentPlayerServing, currentPoint.GetServingPositions(scoreManager.Score));
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
                    currentPoint.advantage.AddAdvantage(currentPoint.currentPlayerShooting);
                    eventReader.OnAdvantageUpdated(currentPoint.advantage);
                    FieldShot(currentPoint.currentPlayerShooting, currentPoint.currentShot.from, currentPoint.currentShot.to, currentPoint.currentShot.type, currentPoint.currentShot.shotTime);
                    eventReader.OnCritEvent(currentPoint.currentPlayerShooting);
                    break;
                case ShotResult.FAIL:
                    Debug.Log(currentPMI.Name() + " fails a " + Shot.GetShotTypeName(currentPoint.currentShot.type) + " @" + currentPoint.currentShot.to.Coord + "!");
                    scoreManager.ScoreAgainst(currentPoint.currentPlayerShooting);
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
            eventReader.OnAdvantageReset();
        }
    }

}
