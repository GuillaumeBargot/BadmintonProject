using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public class ShotCoord
    {
        private readonly string[] tileNames = {"Short Left", "Short Center", "Short Right",
     "Middle Left", "Middle Center", "Middle Right",
     "Long Left", "Long Center", "Long Right"};

        private (int, int) coordinates;

        public (int, int) Get()
        {
            return coordinates;
        }

        public ShotCoord()
        {
            coordinates = Maths.RandCoord();
        }

        public ShotCoord((int, int) coord)
        {
            coordinates = coord;
        }

        public ShotCoord(ShotType.Type type, PlayerMatchInstance player)
        {
            ShotCoordTendencies shotTypeTendencies = ShotType.GetCoordTendencies(type);
            
            ShotCoordTendencies playerTendencies = player.ShotCoordTendencies();
          
            ShotCoordTendencies resultingTendencies = ShotCoordTendencies.Multiply(shotTypeTendencies, playerTendencies);
            coordinates = GetResultingCoordinates(resultingTendencies);
        }

        private (int, int) GetResultingCoordinates(ShotCoordTendencies tendencies){
            return Maths.GetCoordForIndex(Maths.RandWithPercentages(tendencies.coordTendencies));
        }

    }

}
