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
        public int critChance;
        public int normalChance;
        public int failChance;

        public int randomNumber;

        //Type of the shot.
        private int type;

        public void DetermineChances(){
            critChance = 10;
            normalChance = 80;
            failChance = 10;
        }

        private int Random100(){
            return Random.Range(0,100);
        }

        public ShotResult ComputeShot(){
            randomNumber = Random100();

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
