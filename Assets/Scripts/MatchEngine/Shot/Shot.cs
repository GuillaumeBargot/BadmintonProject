using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public class Shot
    {
        //Shot types
        public const int LONG = 0;
        public const int RUSH = 1;
        public const int SMASH = 2;
        public const int SHORT = 3;


        //Quality of the shot. 
        public float critChance;
        public float normalChance;
        public float failChance;

        public ShotCoord shotCoord;

        public float randomNumber;

        //Type of the shot.
        private int type;

        public void DetermineChances(){
            critChance = 10;
            normalChance = 80;
            failChance = 10;
        }

        public ShotResult ComputeShot(){
            randomNumber = Maths.Rand100();
            shotCoord = new ShotCoord();

            if(randomNumber<=critChance){
                return ShotResult.CRIT;
            }else if(randomNumber <= critChance+normalChance){
                return ShotResult.NORMAL;
            }else{
                return ShotResult.FAIL;
            }
        }
    }
}
