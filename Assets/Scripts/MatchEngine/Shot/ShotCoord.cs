using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCoord
{
    private readonly string[] tileNames = {"Short Left", "Short Center", "Short Right",
     "Middle Left", "Middle Center", "Middle Right",
     "Long Left", "Long Center", "Long Right"};
    
   private (int,int) coordinates;

    public (int,int) Get(){
        return coordinates;
    }

    public int GetIndex(){
        return coordinates.Item1*3+coordinates.Item2;
    }

    public ShotCoord(){
        coordinates = Maths.RandCoord();
    }

    public ShotCoord((int, int) coord){
        coordinates = coord;
    }

}
