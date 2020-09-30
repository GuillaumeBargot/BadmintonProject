using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public class Shot
    {
        //Quality of the shot. 
        public ShotChance shotChance;

        public ShotCoord shotCoord;

        public float randomNumber;

        //Type of the shot.
        public ShotType.Type type;


        public ShotResult shotResult;

        public Shot(PlayerMatchInstance player){
            type = player.ShotTypeTendencies().GetShot();
            shotCoord = new ShotCoord(type, player);
            DetermineChances();
        }

        private void DetermineChances(){
            shotChance = new ShotChance();
            shotChance.FromType(type);
        }

        public void ComputeShot(){
            shotResult = shotChance.GetResult();
        }
    }
}
