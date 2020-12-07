using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TileZoneHelper {
    public static int[] GetZoneForTile(int tile){
        switch(tile){
            case 0:
            default:
                return new int[]{3,0,1};
            case 1:
                return new int[]{0,1,2};
            case 2:
                return new int[]{1,2,5};
            case 3:
                return new int[]{0,3,6};
            case 5:
                return new int[]{2,5,8};
            case 6:
                return new int[]{3,6,7};
            case 7:
                return new int[]{6,7,8};
            case 8:
                return new int[]{7,8,5};
        }
    }

    public static int[] GetRandomZone(){
        return GetZoneForTile(Maths.Rand9());
    }
}
