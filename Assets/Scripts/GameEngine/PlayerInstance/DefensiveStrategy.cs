using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameEngine
{

    public class DefensiveStrategy
    {
        private ShotCoord[] defendedCoords;

        public ShotCoord[] DefendedCoords{
            get{
                return defendedCoords;
            }
        }

        public bool IsDefended(ShotCoord coord){
            return Array.Exists(defendedCoords, x => x == coord);
        }

        public DefensiveStrategy(ShotCoord[] defendedCoord)
        {
            this.defendedCoords = defendedCoord;
        }

        public static DefensiveStrategy RandomDefensiveStrategy()
        {
            return new DefensiveStrategy(GetRandomDefendedCoords());
        }

        private static ShotCoord[] GetRandomDefendedCoords(){
            ShotCoord[] result = new ShotCoord[3];
            int[] tiles = TileZoneHelper.GetRandomZone();
            for(int i = 0; i < 3; i++){
                result[i] = new ShotCoord(tiles[i]);
            }
            return result;
        }
    }
}
