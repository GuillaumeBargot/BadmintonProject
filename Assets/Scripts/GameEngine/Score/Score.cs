using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameEngine
{
    [System.Serializable]
    public class Score
    {
        private (int, int) matchScore;
        private (int, int)[] setsScores;
        private int currentSet;

        //------------------------------ CREATION ---------------------------------


        public Score(int nbSets)
        {
            setsScores = new (int, int)[nbSets].Populate((0, 0));
            matchScore = (0, 0);
            currentSet = 0;
        }
        public Score((int, int) matchScore, (int, int)[] setsScores, int currentSet)
        {
            this.setsScores = setsScores;
            this.matchScore = matchScore;
            this.currentSet = currentSet;
        }

        //------------------------------ POINTS HANDLING ---------------------------------

        public void AddPoint(int player)
        {
            if (player == 0)
            {
                setsScores[currentSet].Item1++;
            }
            else
            {
                setsScores[currentSet].Item2++;
            }
        }

        public void AddSet(int player)
        {
            if (player == 0)
            {
                matchScore.Item1++;
            }
            else
            {
                matchScore.Item2++;
            }
        }

        public void NextCurrentSet(){
            currentSet++;
        }

        public (int, int) GetCurrentSetScore()
        {
            return setsScores[currentSet];
        }
        public (int, int) GetMatchScore(){
            return matchScore;
        }

        public void LogScore()
        {
            for (int i = 0; i <= currentSet; i++)
            {
                Debug.Log(setsScores[i].Item1 + " / " + setsScores[i].Item2);
            }
        }
    }
}
