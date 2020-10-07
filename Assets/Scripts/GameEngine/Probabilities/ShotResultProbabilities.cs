using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public class ShotResultProbabilities : Probabilities<ShotResult>
    {
        //CONSTANTS
        public static readonly float[] BASE_PROBABILITIES = new float[]{10.0f,80.0f,10.0f};

        private static readonly float[] LONG_RESULT_PROBABILITIES = { 2f,90f,8f };

        private static readonly float[] RUSH_RESULT_PROBABILITIES = { 10f,75f,15f };

        private static readonly float[] SMASH_RESULT_PROBABILITIES = { 25f,55f,20f};

        private static readonly float[] SHORT_RESULT_PROBABILITIES = { 25f,55f,20f };

        //PUBLIC GETTERS
        public float Crit{
            get{
                return probabilities[0];
            }
        }

        public float Normal{
            get{
                return probabilities[1];
            }
        }

        public float Fail{
            get{
                return probabilities[2];
            }
        }

        // CONSTRUCTORS
        public ShotResultProbabilities() : base(BASE_PROBABILITIES) { }
        public ShotResultProbabilities(float[] probabilities) : base(probabilities) { }

        public static ShotResultProbabilities LongResultProbabilities() => new ShotResultProbabilities(LONG_RESULT_PROBABILITIES);
        public static ShotResultProbabilities RushResultProbabilities() => new ShotResultProbabilities(RUSH_RESULT_PROBABILITIES);
        public static ShotResultProbabilities SmashResultProbabilities() => new ShotResultProbabilities(SMASH_RESULT_PROBABILITIES);
        public static ShotResultProbabilities ShortResultProbabilities() => new ShotResultProbabilities(SHORT_RESULT_PROBABILITIES);

        protected override void SetAssociatedResults()
        {
            associatedResults = new ShotResult[] { ShotResult.CRIT, ShotResult.NORMAL, ShotResult.FAIL };
        }

        public static ShotResultProbabilities GetShotTypeResultProbabilities(ShotType.Type type)
        {
            switch (type)
            {
                case ShotType.Type.LONG:
                    return LongResultProbabilities();
                case ShotType.Type.RUSH:
                    return RushResultProbabilities();
                case ShotType.Type.SMASH:
                    return SmashResultProbabilities();
                case ShotType.Type.SHORT:
                    return ShortResultProbabilities();
            }
            return new ShotResultProbabilities();
        }

        public static ShotResultProbabilities RandomProbabilities()
        {
            float randomFail = Random.Range(1, 49);
            float randomCrit = Random.Range(1, 49);
            float randomNormal = 100 - randomCrit - randomFail;
            return new ShotResultProbabilities(new float[]{randomCrit, randomNormal, randomFail});
        }
    }
}
