using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public class ShotResultProbabilities : Probabilities<ShotResult>
    {
        //CONSTANTS
        public static float[] BASE_PROBABILITIES => new float[]{10.0f,90.0f,0f};

        private static float[] LONG_RESULT_PROBABILITIES => new float[]{ 5f,95f,0f };

        private static float[] RUSH_RESULT_PROBABILITIES => new float[]{ 8f,92f,0f };

        private static float[] SMASH_RESULT_PROBABILITIES => new float[]{ 15f,85f,0f};

        private static float[] SHORT_RESULT_PROBABILITIES => new float[]{ 15f,85f,0f };

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

        public static ShotResultProbabilities GetShotTypeResultProbabilities(ShotType type)
        {
            switch (type)
            {
                case ShotType.LONG:
                    return LongResultProbabilities();
                case ShotType.RUSH:
                    return RushResultProbabilities();
                case ShotType.SMASH:
                    return SmashResultProbabilities();
                case ShotType.SHORT:
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

        public void AddCrit(float addedCrit){
            if(Crit+addedCrit>100 || Crit+addedCrit < 0) return;
            //First add the added crit onto the crit.
            probabilities[0] = probabilities[0] + addedCrit;

            if(Normal<addedCrit){
                //Weird behaviour, there is no "normal" left for "crit" to be added into. You have to start cronching some of "fail" percentages
                float remainingAddedCrit = addedCrit - Normal;
                probabilities[1] = 0;
                probabilities[2] = probabilities[2] - remainingAddedCrit;
            }else{
                //Normal behaviour, we borrow some percentages from the "normal" case to add some "crit".
                probabilities[1] = probabilities[1] - addedCrit;
            }
        }

        public void AddFail(float addedFail){
            if(Fail+addedFail>100 || Fail+addedFail < 0) return;
            //First add the added crit onto the crit.
            probabilities[2] = probabilities[2] + addedFail;

            if(Normal<addedFail){
                //Weird behaviour, there is no "normal" left for "crit" to be added into. You have to start cronching some of "fail" percentages
                float remainingAddedFail = addedFail - Normal;
                probabilities[1] = 0;
                probabilities[0] = probabilities[0] - remainingAddedFail;
            }else{
                //Normal behaviour, we borrow some percentages from the "normal" case to add some "crit".
                probabilities[1] = probabilities[1] - addedFail;
            }
        }

        public void Log(){
            Debug.Log("ShotResultProbs: " + Crit + "% / " + Normal + "% / " + Fail + "%");
        }
    }
}
