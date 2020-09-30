using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEngine;

public class ShotCoordTendencies
{
    public float[] coordTendencies;

    private static readonly float[] DEFAULT_COORD_TENDENCIES = {11f,11f,11f,11f,12f,11f,11f,11f,11f};

    private static readonly float[] LONG_COORD_TENDENCIES = {0f,0f,0f,0f,0f,0f,33f,34f,33f};

    private static readonly float[] RUSH_COORD_TENDENCIES = {0f,0f,0f,17f,17f,17f,16f,17f,16f};

    private static readonly float[] SMASH_COORD_TENDENCIES = {0,0,0,33,34,33,0,0,0};

    private static readonly float[] SHORT_COORD_TENDENCIES = {33f,34f,33f,0f,0f,0f,0f,0f,0f};

    public ShotCoordTendencies(){
        coordTendencies = DEFAULT_COORD_TENDENCIES;
    }

    private ShotCoordTendencies(float[] tendencies){
        coordTendencies = tendencies;
    }


    public static ShotCoordTendencies GetShotTypeCoordTendencies(ShotType.Type type){
        switch(type){
            case ShotType.Type.LONG:
                return LongShotCoordTendencies();
            case ShotType.Type.RUSH:
                return RushCoordTendencies();
            case ShotType.Type.SMASH:
                return SmashCoordTendencies();
            case ShotType.Type.SHORT:
                return ShortShotCoordTendencies();
        }
        return new ShotCoordTendencies();
    }

    public static ShotCoordTendencies Multiply(ShotCoordTendencies sct1, ShotCoordTendencies sct2){
        return new ShotCoordTendencies(Maths.MergeCoordTendencies(sct1.coordTendencies,sct2.coordTendencies));
    }
    private static ShotCoordTendencies LongShotCoordTendencies(){
        return new ShotCoordTendencies(LONG_COORD_TENDENCIES);
    }

    private static ShotCoordTendencies RushCoordTendencies(){
        return new ShotCoordTendencies(RUSH_COORD_TENDENCIES);
    }

    private static ShotCoordTendencies SmashCoordTendencies(){
        return new ShotCoordTendencies(SMASH_COORD_TENDENCIES);
    }

    private static ShotCoordTendencies ShortShotCoordTendencies(){
        return new ShotCoordTendencies(SHORT_COORD_TENDENCIES);
    }

    private void SetDefaultTendencies(){
        coordTendencies = DEFAULT_COORD_TENDENCIES;
    }

    public void Log(){
        Debug.Log("--------------------CoordTendencies--------------------");
        Debug.Log("  " + coordTendencies[0] + " / " + coordTendencies[1] + " / " + coordTendencies[2]);
        Debug.Log("  " + coordTendencies[3] + " / " + coordTendencies[4] + " / " + coordTendencies[5]);
        Debug.Log("  " + coordTendencies[6] + " / " + coordTendencies[7] + " / " + coordTendencies[8]);
    }
}
