using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEngine
{
    public class HistoryShot
    {
        public int playerShooting;
        public (int, int) from;
        public (int, int) to;

        public ShotType.Type type;

        public HistoryShot(int playerShooting, (int, int) from, (int, int) to, ShotType.Type type){
            this.playerShooting = playerShooting;
            this.from = from;
            this.to = to;
            this.type = type;
        }
    }
}
