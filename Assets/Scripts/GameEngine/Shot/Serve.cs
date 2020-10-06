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
            int points = (playerShooting==0)?(score.GetMatchScore().Item1):(score.GetMatchScore().Item2);
            side = (points%2==0)?Side.RIGHT:Side.LEFT;
            SetFrom();
            SetTo(); 
            isServe = true;
        }

        private void SetFrom(){
            from = (side==Side.RIGHT)?(1,2):(1,0);
        }

        private void SetTo(){
            to = (side==Side.RIGHT)?(2,0):(2,2);
        }
    }
}
