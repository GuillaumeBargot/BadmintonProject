using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public static class ShotType
    {
        public static int SHOT_NUMBER = 4;
        public enum Type
        {
            LONG = 0,
            RUSH = 1,
            SMASH = 2,
            SHORT = 3
        }

        public static ShotCoordTendencies GetCoordTendencies(Type type){
            return ShotCoordTendencies.GetShotTypeCoordTendencies(type);
        }
        
        public static string GetName(Type type){
            switch(type){
                case Type.LONG:
                    return "Long Shot";
                case Type.RUSH:
                    return "Rush";
                case Type.SMASH:
                    return "Smash";
                case Type.SHORT:
                    return "Short Shot";
            }
            return "Unknown Shot";
        }
    }

}
