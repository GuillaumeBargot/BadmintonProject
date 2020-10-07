using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public class Serve : Shot
    {
        public enum Side
        {
            RIGHT,
            LEFT
        }

        public Side side;

        

        public Serve(int playerShooting, Score score) : base(playerShooting){
            int points = (playerShooting==0)?(score.GetCurrentSetScore().Item1):(score.GetCurrentSetScore().Item2);
            side = (points%2==0)?Side.RIGHT:Side.LEFT;
            SetFrom();
            SetTo(); 
            isServe = true;
        }

        private void SetFrom(){
            from = (side==Side.RIGHT)?(2,1):(0,1);
        }

        private void SetTo(){
            to = (side==Side.RIGHT)?(2,2):(0,2);
        }

        public ((int, int), (int, int)) GetPlayerIntialPositions(){
            return (from, to);
        }
    }
}
