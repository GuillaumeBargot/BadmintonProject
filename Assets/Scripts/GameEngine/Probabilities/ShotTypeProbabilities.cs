﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public class ShotTypeProbabilities : Probabilities<ShotType>
    {
        //CONSTANTS
        private static float[] BASE_PROBABILITIES => new float[]{40,20,10,30};

        private static float[] FOLLOWING_LONG_PROBABILITIES => new float[]{60f,0,20f,20f};

        private static float[] FOLLOWIN_RUSH_PROBABILITIES => new float[]{30f,60f,5f,5f};

        private static float[] FOLLOWING_SMASH_PROBABILITIES => new float[]{70f,0f,30f,0f};

        private static float[] FOLLOWING_SHORT_PROBABILITIES => new float[]{30f,40f,30f,0f};

        // CONSTRUCTORS
        public ShotTypeProbabilities() : base (BASE_PROBABILITIES){}
        public ShotTypeProbabilities(float[] probabilities) : base(probabilities){}

        public static ShotTypeProbabilities FollowingLongTypeProbabilities() => new ShotTypeProbabilities(FOLLOWING_LONG_PROBABILITIES);
        public static ShotTypeProbabilities FollowingRushTypeProbabilities() => new ShotTypeProbabilities(FOLLOWIN_RUSH_PROBABILITIES);
        public static ShotTypeProbabilities FollowingSmashTypeProbabilities() => new ShotTypeProbabilities(FOLLOWING_SMASH_PROBABILITIES);
        public static ShotTypeProbabilities FollowingShortTypeProbabilities() => new ShotTypeProbabilities(FOLLOWING_SHORT_PROBABILITIES);
        
        protected override void SetAssociatedResults(){
            associatedResults = new ShotType[]{ShotType.LONG, ShotType.RUSH, ShotType.SHORT,ShotType.SMASH};
        }


        public static ShotTypeProbabilities GetShotTypeProbabilitiesFollowing(ShotType type)
        {
            switch (type)
            {
                case ShotType.LONG:
                    return FollowingLongTypeProbabilities();
                case ShotType.RUSH:
                    return FollowingRushTypeProbabilities();
                case ShotType.SMASH:
                    return FollowingSmashTypeProbabilities();
                case ShotType.SHORT:
                    return FollowingShortTypeProbabilities();
            }
            return new ShotTypeProbabilities();
        }
    }
}
