using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameEngine
{
    public class Score
    {

        private static int MAX_POINTS = 21;

        private static int MIN_DIFFERENCE = 2;

        private static int MAX_MAX_POINTS = 30;

        private (int, int) matchScore;
        private (int, int)[] setsScores;
        private int currentSet;

        private bool matchOver = false;

        //------------------------------ CREATION ---------------------------------
        public static Score CreateBO3Match()
        {
            return CreateBestOfMatch(3);
        }

        public static Score CreateBO5Match()
        {
            return CreateBestOfMatch(5);
        }

        private static Score CreateBestOfMatch(int nbSets)
        {
            (int, int)[] setsScores = new (int, int)[nbSets].Populate((0, 0));
            (int, int) matchScore = (0, 0);
            int currentSet = 0;
            return new Score(setsScores, matchScore, currentSet);
        }

        private Score((int, int)[] setsScores, (int, int) matchScore, int currentSet)
        {
            this.setsScores = setsScores;
            this.matchScore = matchScore;
            this.currentSet = currentSet;
        }

        //------------------------------ POINTS HANDLING ---------------------------------

        public void PointPlayer1()
        {
            setsScores[currentSet].Item1++;
            Checks();
        }

        public void PointPlayer2()
        {
            setsScores[currentSet].Item2++;
            Checks();
        }

        public void ScoreFor(int playerID)
        {
            if (playerID == 0)
            {
                PointPlayer1();
            }
            else
            {
                PointPlayer2();
            }
        }

        public void ScoreAgainst(int playerID)
        {
            if (playerID == 0)
            {
                PointPlayer2();
            }
            else
            {
                PointPlayer1();
            }
        }

        //------------------------------ CHECKERS ---------------------------------

        public void Checks()
        {
            if (CheckIfEndOfSet())
            {
                ProceedChangeOfSet();
            }
        }
        public bool CheckIfEndOfSet()
        {
            (int score1, int score2) = setsScores[currentSet];
            if ( SomeoneOver21(score1, score2) &&
            ( DifferenceOver2(score1, score2) || SomeoneAtMaxScore(score1, score2)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool SomeoneOver21(int score1, int score2){
            return (score1 >= MAX_POINTS || score2 >= MAX_POINTS);
        }

        private bool DifferenceOver2(int score1, int score2){
            return (Math.Abs(score1 - score2) >= MIN_DIFFERENCE);
        }

        private bool SomeoneAtMaxScore(int score1, int score2){
            return (score1<=MAX_MAX_POINTS || score2<=MAX_MAX_POINTS);
        }

        public void ProceedChangeOfSet()
        {
            if (setsScores[currentSet].Item1 > setsScores[currentSet].Item2)
            {
                matchScore.Item1++;
            }
            else
            {
                matchScore.Item2++;
            }
            if (!CheckIfEndOfMatch())
            {
                currentSet++;
            }
            else
            {
                MatchOver();
            }
        }

        public bool CheckIfEndOfMatch()
        {
            int numberToBeat = setsScores.Length / 2;
            if (matchScore.Item1 > numberToBeat || matchScore.Item2 > numberToBeat)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void MatchOver()
        {
            matchOver = true;
        }

        //------------------------------ GETTERS ---------------------------------

        public void LogScore()
        {
            for (int i = 0; i <= currentSet; i++)
            {
                Debug.Log(setsScores[i].Item1 + " / " + setsScores[i].Item2);
            }
        }

        public ScoreRecap GetScoreRecap()
        {
            return new ScoreRecap(matchScore, setsScores[currentSet]);
        }
        public (int, int)[] GetSetsScores()
        {
            return setsScores;
        }

        public (int, int) GetMatchScore()
        {
            return matchScore;
        }

        public (int, int) GetCurrentSetScore(){
            return setsScores[currentSet];
        }

    }
}
