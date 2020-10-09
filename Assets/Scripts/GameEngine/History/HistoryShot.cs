using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEngine
{
    public class HistoryShot
    {
        public int playerShooting;
        public ShotCoord from;
        public ShotCoord to;

        public ShotType type;

        public HistoryShot(int playerShooting, ShotCoord from, ShotCoord to, ShotType type){
            this.playerShooting = playerShooting;
            this.from = from;
            this.to = to;
            this.type = type;
        }
    }
}
