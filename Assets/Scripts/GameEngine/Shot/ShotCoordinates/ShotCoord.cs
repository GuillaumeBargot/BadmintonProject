using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{

    //TODO : REFACTOR THIS SHIT. I WANT A CLASS CALLED SHOTCOORD THAT HAS AN INT INSIDE AND CAN RETURN YOU EITHER THE INT (INDEX) Or
    // THE COORDINATES IN A (int, int) BULLSHIT BUT THEN DOES NOTHING ELSE. THE CALCULATING OF THE SHOT COORD SHOULD BE DONE IN A SHOTMAKER
    // RELATED CLASS
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
            ShotCoordProbabilities shotTypeTendencies = ShotType.GetCoordTendencies(type);
            
            ShotCoordProbabilities playerTendencies = player.ShotCoordTendencies();
          
            ShotCoordProbabilities resultingTendencies = ShotCoordProbabilities.Multiply(shotTypeTendencies, playerTendencies);
            coordinates = GetResultingCoordinates(resultingTendencies);
        }

        private (int, int) GetResultingCoordinates(ShotCoordProbabilities tendencies){
            return tendencies.Calculate();
        }

    }

}
