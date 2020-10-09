using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public class Shot
    {
        //Quality of the shot. 
        public ShotResultProbabilities shotResultProbabilities;

        //public ShotCoord shotCoord;

        public float randomNumber;

        public ShotCoord from;
        public ShotCoord to;

        //Type of the shot.
        public ShotType type;

        public bool isServe = false;

        public int playerShooting;

        public ShotResult shotResult;

        //Constructor to be used by ShotMaker
        public Shot(int playerShooting, ShotType type, ShotCoord from, ShotCoord to, ShotResultProbabilities shotResultProbabilities, bool isServe)
        {
            this.playerShooting = playerShooting;
            this.type = type;
            this.from = from;
            this.to = to;
            this.shotResultProbabilities = shotResultProbabilities;
        }

        public void ComputeShot()
        {
            shotResult = shotResultProbabilities.Calculate();
        }

        public static string GetShotTypeName(ShotType type)
        {
            switch (type)
            {
                case ShotType.LONG:
                    return "Long Shot";
                case ShotType.RUSH:
                    return "Rush";
                case ShotType.SMASH:
                    return "Smash";
                case ShotType.SHORT:
                    return "Short Shot";
            }
            return "Unknown Shot";
        }

        public HistoryShot GetHistoryShot()
        {
            return new HistoryShot(playerShooting, from, to, ShotType.LONG);
        }
    }
}
