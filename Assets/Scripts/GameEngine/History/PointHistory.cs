using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEngine
{
    public class PointHistory
    {
        private List<List<HistoryPoint>> points;

        public PointHistory(){
            //Creating the list
            points = new List<List<HistoryPoint>>();
            AddSet();
        }

        public void AddSet(){
            points.Add(new List<HistoryPoint>());
        }

        public void AddHistoryPoint(HistoryPoint point){
            if(points.Count == 0) return;

            points[points.Count-1].Add(point);
        }

        public int GetLastPointWinner(){
            if(points.Count==0) return -1;
            List<HistoryPoint> lastSet = points[points.Count-1];
            if(lastSet.Count==0) return -1;
            return lastSet[lastSet.Count-1].playerWinning;

        }

        public bool FirstPoint(){
            if(points.Count==0) return true;
            List<HistoryPoint> lastSet = points[points.Count-1];
            if(lastSet.Count==0) return true;
            return false;
        }
        
    }

}
