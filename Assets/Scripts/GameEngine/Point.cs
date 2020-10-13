using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public class Point
    {
        public bool pointOver;
        public Shot currentShot;
        public int currentPlayerShooting;

        public int currentPlayerServing;
        public Advantage advantage;

        private List<HistoryShot> shotHistory;

        public Point(Score score, PointHistory history)
        {
            shotHistory = new List<HistoryShot>();
            pointOver = false;
            advantage = new Advantage();

            //TODO TOSS RIGHT THERE
            if (history.FirstPoint())
            {
                currentPlayerServing = 0;
                Serve serve = ShotMaker.CreateServe(currentPlayerServing, score);
                currentShot = serve;
            }
            else
            {
                currentPlayerServing = history.GetLastPointWinner();
                Serve serve = ShotMaker.CreateServe(currentPlayerServing, score);
                currentShot = serve;
            }
        }

        public void NewShotIfNotServe()
        {
            if (shotHistory.Count == 0) return;
            currentPlayerShooting = (currentPlayerShooting == 0) ? 1 : 0;
            Shot shot = ShotMaker.CreateShot(currentPlayerShooting, currentShot, advantage);
            currentShot = shot;
        }

        public HistoryPoint GetHistoryPoint()
        {
            return new HistoryPoint(currentPlayerShooting, shotHistory.Count, shotHistory[shotHistory.Count - 1]);
        }


        // GAME LOOP

        public void ComputeCurrentShot()
        {
            currentShot.ComputeShot();
        }

        public void ProcessFinishedShot()
        {
            shotHistory.Add(currentShot.GetHistoryShot());
        }

        public (ShotCoord, ShotCoord) GetServingPositions(Score score){
            return ShotMaker.GetPlayerIntialPositions(currentPlayerServing,score);
        }
    }
}
