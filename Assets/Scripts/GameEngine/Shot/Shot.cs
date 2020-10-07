using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public class Shot
    {
        //Quality of the shot. 
        public ShotResultProbabilities shotResultProbabilities;

        public ShotCoord shotCoord;

        public float randomNumber;

        public (int, int) from;
        public (int, int) to;

        //Type of the shot.
        public ShotType.Type type;

        public bool isServe = false;

        public int playerShooting;

        public PlayerMatchInstance player;

        public ShotResult shotResult;

        public Shot(int playerShooting, Shot previousShot){
            player = MatchEngine.Instance.GetPlayer(playerShooting);
            type = player.ShotTypeProbabilities().Calculate();
            this.playerShooting = playerShooting;
            from = previousShot.to;
            shotCoord = new ShotCoord(type, player);
            to = shotCoord.Get();
            DetermineChances();
        }

        public Shot(int playerShooting){
            player = MatchEngine.Instance.GetPlayer(playerShooting);
            type = player.ShotTypeProbabilities().Calculate();
            this.playerShooting = playerShooting;
            shotCoord = new ShotCoord(type, player);
            to = shotCoord.Get();
            DetermineChances();
        }

        private void DetermineChances(){
            shotResultProbabilities = ShotResultProbabilities.GetShotTypeResultProbabilities(type);
        }

        public void ComputeShot(){
            shotResult = shotResultProbabilities.Calculate();
        }

        public HistoryShot GetHistoryShot(){
            return new HistoryShot(playerShooting, from, to, ShotType.Type.LONG);
        }
    }
}
