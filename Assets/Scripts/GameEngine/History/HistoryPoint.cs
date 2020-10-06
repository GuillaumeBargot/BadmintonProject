using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public class HistoryPoint
    {

        //GLOBAL
        public int playerWinning;
        public int numberOfShots;

        //LAST SHOT
        public (int, int) lastShotFrom;
        public (int, int) lastShotTo;
        public ShotType.Type lastShotType;

        public HistoryPoint(int playerWinning, int numberOfShots, HistoryShot lastShot){
            this.playerWinning = playerWinning;
            this.numberOfShots = numberOfShots;
            this.lastShotFrom = lastShot.from;
            this.lastShotTo = lastShot.to;
            this.lastShotType = lastShot.type;
        }

    }
}
