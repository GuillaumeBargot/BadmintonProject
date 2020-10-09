using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public class Serve : Shot
    {
        public Serve(int playerShooting, ShotType type, ShotCoord from, ShotCoord to, ShotResultProbabilities shotResultProbabilities)
            : base(playerShooting, type, from, to, shotResultProbabilities, true){}
    }
}
