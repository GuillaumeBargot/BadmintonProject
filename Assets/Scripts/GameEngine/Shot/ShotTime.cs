using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEngine
{
    public static class ShotTime
    {
        public static float GetTimeForType(ShotType type)
        {
            switch(type){
                case ShotType.RUSH:
                case ShotType.SMASH:
                    return 0.33f;
                case ShotType.LONG:
                case ShotType.SHORT:
                default:
                    return 0.50f;
            }
        }
    }
}
