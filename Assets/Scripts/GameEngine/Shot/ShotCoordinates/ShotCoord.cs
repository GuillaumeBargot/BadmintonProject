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

        public (int, int) Coord
        {
            get
            {
                return coordinates;
            }
        }
        public int Index
        {
            get
            {
                return Maths.GetIndexForCoord(coordinates);
            }
        }

        public ShotCoord()
        {
            coordinates = Maths.RandCoord();
        }

        public ShotCoord((int, int) coord)
        {
            coordinates = coord;
        }

    }

}
