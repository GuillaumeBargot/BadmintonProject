using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{

    public static class ShotTypeProbabilitiesHelper
    {
        //The enum here MUST be exactly the same as the ID you put inside your Playstyle Scriptable Objects
        public enum NAME
        {
            BASE,
            FOLLOWING_LONG,
            FOLLOWING_RUSH,
            FOLLOWING_SMASH,
            FOLLOWING_SHORT,
            PLAYSTYLE_AGGRESSIVE_SMASHING

        }

        public static ShotTypeProbabilities GetProbabilities(NAME name)
        {
            return ScriptableObjectHelper.GetShotTypeProbabilitiesWithId(name.ToString());
        }
    }
}
