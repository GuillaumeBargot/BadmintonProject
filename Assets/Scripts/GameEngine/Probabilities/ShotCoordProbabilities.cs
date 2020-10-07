using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public class ShotCoordProbabilities : Probabilities<(int, int)>
    {
        //CONSTANTS
        private static readonly float[] DEFAULT_COORD_TENDENCIES = { 11f, 11f, 11f, 11f, 12f, 11f, 11f, 11f, 11f };

        private static readonly float[] LONG_COORD_PROBABILITIES = { 0f, 0f, 0f, 0f, 0f, 0f, 33f, 34f, 33f };

        private static readonly float[] RUSH_COORD_PROBABILITIES = { 0f, 0f, 0f, 17f, 17f, 17f, 16f, 17f, 16f };

        private static readonly float[] SMASH_COORD_PROBABILITIES = { 0, 0, 0, 33, 34, 33, 0, 0, 0 };

        private static readonly float[] SHORT_COORD_PROBABILITIES = { 33f, 34f, 33f, 0f, 0f, 0f, 0f, 0f, 0f };

        // CONSTRUCTORS
        public ShotCoordProbabilities() : base(DEFAULT_COORD_TENDENCIES) { }
        public ShotCoordProbabilities(float[] probabilities) : base(probabilities) { }

        public static ShotCoordProbabilities LongCoordProbabilities() => new ShotCoordProbabilities(LONG_COORD_PROBABILITIES);
        public static ShotCoordProbabilities RushCoordProbabilities() => new ShotCoordProbabilities(RUSH_COORD_PROBABILITIES);
        public static ShotCoordProbabilities SmashCoordProbabilities() => new ShotCoordProbabilities(SMASH_COORD_PROBABILITIES);
        public static ShotCoordProbabilities ShortCoordProbabilities() => new ShotCoordProbabilities(SHORT_COORD_PROBABILITIES);

        protected override void SetAssociatedResults()
        {
            associatedResults = new (int, int)[] { (0, 0), (1, 0), (2, 0), (0, 1), (1, 1), (2, 1), (0, 2), (1, 2), (2, 2) };
        }


        public static ShotCoordProbabilities GetShotTypeCoordProbabilities(ShotType.Type type)
        {
            switch (type)
            {
                case ShotType.Type.LONG:
                    return LongCoordProbabilities();
                case ShotType.Type.RUSH:
                    return RushCoordProbabilities();
                case ShotType.Type.SMASH:
                    return SmashCoordProbabilities();
                case ShotType.Type.SHORT:
                    return ShortCoordProbabilities();
            }
            return new ShotCoordProbabilities();
        }

        public static ShotCoordProbabilities Multiply(ShotCoordProbabilities prob1, ShotCoordProbabilities prob2)
        {
            return new ShotCoordProbabilities(MergeProbabilities(prob1.probabilities, prob2.probabilities));
        }

        public void Log()
        {
            Debug.Log("--------------------CoordProbabilities--------------------");
            Debug.Log("  " + probabilities[0] + " / " + probabilities[1] + " / " + probabilities[2]);
            Debug.Log("  " + probabilities[3] + " / " + probabilities[4] + " / " + probabilities[5]);
            Debug.Log("  " + probabilities[6] + " / " + probabilities[7] + " / " + probabilities[8]);
        }

    }
}
