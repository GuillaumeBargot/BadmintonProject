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

        private List<HistoryShot> shotHistory;

        public Point(int playerServing, Score score, PointHistory history)
        {
            shotHistory = new List<HistoryShot>();
            pointOver = false;

            //TODO TOSS RIGHT THERE
            if (history.FirstPoint())
            {
                Serve serve = new Serve(0, score);
                currentShot = serve;
            }
            else
            {
                Serve serve = new Serve(history.GetLastPointWinner(), score);
                currentShot = serve;
            }
        }

        public void NewShotIfNotServe()
        {
            if (shotHistory.Count == 0) return;
            currentPlayerShooting = (currentPlayerShooting == 0) ? 1 : 0;
            Shot shot = new Shot(currentPlayerShooting, currentShot);
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

        public ((int, int), (int, int)) GetServingPositions(){
            return ((Serve)currentShot).GetPlayerIntialPositions();
        }
    }
}
