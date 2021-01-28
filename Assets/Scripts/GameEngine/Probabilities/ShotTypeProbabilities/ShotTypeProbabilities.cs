using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using NAME = GameEngine.ShotTypeProbabilitiesHelper.NAME;
namespace GameEngine
{
    [CreateAssetMenu(fileName = "ShotTypeProbabilities", menuName = "GameEngine/ShotTypeProbabilities", order = 1)]
    public class ShotTypeProbabilities : ProbabilitiesSO<ShotType>
    {
        //CONSTANTS
        private static float[] BASE_PROBABILITIES => new float[] { 40, 20, 10, 30 };

        /*private static float[] FOLLOWING_LONG_PROBABILITIES => new float[] { 60f, 0, 20f, 20f };

        private static float[] FOLLOWIN_RUSH_PROBABILITIES => new float[] { 30f, 60f, 5f, 5f };

        private static float[] FOLLOWING_SMASH_PROBABILITIES => new float[] { 70f, 0f, 30f, 0f };

        private static float[] FOLLOWING_SHORT_PROBABILITIES => new float[] { 30f, 40f, 30f, 0f };*/

        // CONSTRUCTORS
        public ShotTypeProbabilities() : base(BASE_PROBABILITIES) { }
        public ShotTypeProbabilities(float[] probabilities) : base(probabilities) { }

        public static ShotTypeProbabilities FollowingLongTypeProbabilities() => ShotTypeProbabilitiesHelper.GetProbabilities(NAME.FOLLOWING_LONG);
        public static ShotTypeProbabilities FollowingRushTypeProbabilities() => ShotTypeProbabilitiesHelper.GetProbabilities(NAME.FOLLOWING_RUSH);
        public static ShotTypeProbabilities FollowingSmashTypeProbabilities() => ShotTypeProbabilitiesHelper.GetProbabilities(NAME.FOLLOWING_SMASH);
        public static ShotTypeProbabilities FollowingShortTypeProbabilities() => ShotTypeProbabilitiesHelper.GetProbabilities(NAME.FOLLOWING_SHORT);

        protected override void SetAssociatedResults()
        {
            associatedResults = new ShotType[] { ShotType.LONG, ShotType.RUSH, ShotType.SHORT, ShotType.SMASH };
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

        public void MergeWith(ShotTypeProbabilities prob2)
        {
            MergeProbabilitiesWith(prob2.probabilities);
            //return new ShotTypeProbabilities(MergeProbabilities(prob1.probabilities, prob2.probabilities));
        }
    }
}
