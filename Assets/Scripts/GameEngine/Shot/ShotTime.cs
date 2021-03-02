using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEngine
{
    public static class ShotTime
    {
        public static float GetTimeForType(ShotType type, MatchPreferences preferences)
        {
            switch(type){
                case ShotType.RUSH:
                case ShotType.SMASH:
                    return 0.15f * (float)(preferences.speedx10?0.1:1); //10 fois plus fort qu'avant, pareil pour l'autre, pls enlever un 0;
                case ShotType.LONG:
                case ShotType.SHORT:
                default:
                    return 0.25f * (float)(preferences.speedx10?0.1:1);
            }
        }
    }
}
