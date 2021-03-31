using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameEngine
{

    public class ScoreManager
    {
        private static int MAX_POINTS = 21;

        private static int MIN_DIFFERENCE = 2;

        private static int MAX_MAX_POINTS = 30;

        public bool isSingleMatch = false;

        private Score localScore;

        public Score Score{
            get{
                if(isSingleMatch){
                    return localScore;
                }else{
                    return SaveData.current.calendar.GetTournament().currentMatch.score;
                }
            }
        }

        private bool matchOver = false;

        private int maxSet;

        private MatchEventReader eventReader;

        public static ScoreManager CreateBO3Match(MatchEventReader eventReader)
        {
            return CreateBestOfMatch(3, eventReader);
        }

        public static ScoreManager CreateBO5Match(MatchEventReader eventReader)
        {
            return CreateBestOfMatch(5, eventReader);
        }

        private static ScoreManager CreateBestOfMatch(int nbSets, MatchEventReader eventReader)
        {
            return new ScoreManager(nbSets, eventReader);
        }

        private ScoreManager(int nbSets, MatchEventReader eventReader)
        {
            this.eventReader = eventReader;
            this.maxSet = nbSets;
            if(!SaveData.CurrentMatchExists){
                this.localScore = new Score(nbSets);
                this.isSingleMatch = true;
            }
        }

        //-----------------------POINT HANDLING--------------------------------------------------

        public void PointPlayer1()
        {
            Score.AddPoint(0);
            Checks();
        }

        public void PointPlayer2()
        {
            Score.AddPoint(1);
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
                Debug.Log("-------END OF SET--------");
                eventReader.OnNewSet();
            }
        }
        public bool CheckIfEndOfSet()
        {
            (int score1, int score2) = Score.GetCurrentSetScore();
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
            return (score1>=MAX_MAX_POINTS || score2>=MAX_MAX_POINTS);
        }

        public void ProceedChangeOfSet()
        {
            Debug.Log("Proceeding change of Set");
            (int, int) setScore = Score.GetCurrentSetScore();
            Score.AddSet(setScore.Item1>setScore.Item2?0:1);
            if (!CheckIfEndOfMatch())
            {
                Score.NextCurrentSet();
            }
            else
            {
                MatchOver();
            }
        }

        public bool CheckIfEndOfMatch()
        {
            int numberToBeat = maxSet / 2;
            (int, int) matchScore = Score.GetMatchScore();
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
            Debug.Log("MATCHOVER");
            matchOver = true;
            eventReader.OnMatchOver();
            
        }

        //------------------------------ GETTERS ---------------------------------

        public void LogScore()
        {
            Score.LogScore();
        }

        public int WhoWon(){
            if(!matchOver){
                return -1;
            }
            else{
                return (GetMatchScore().Item1>GetMatchScore().Item2)?0:1;
            }
        }

        public (int, int) GetMatchScore()
        {
            return Score.GetMatchScore();
        }

        public (int, int) GetCurrentSetScore(){
            return Score.GetCurrentSetScore();
        }

    }

}
