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
            if(addedCrit>=0){
                AddPositiveCrit(addedCrit);
            }else{
                AddNegativeCrit(addedCrit);
            }
        }

        private void AddPositiveCrit(float addedCrit){
            if(Crit + addedCrit >= 100){
                probabilities[0] = 100.0f;
                probabilities[1] = 0;
                probabilities[2] = 0;
            }else{
                if(Normal == 0){
                    probabilities[0] += addedCrit;
                    probabilities[2] -= addedCrit;
                }else{
                    if(Normal-addedCrit>=0){
                        probabilities[0] += addedCrit;
                        probabilities[1] -= addedCrit;
                    }else{
                        float remainder = addedCrit - Normal;
                        probabilities[0] += addedCrit;
                        probabilities[1] = 0;
                        probabilities[2] -= remainder;
                    }
                }
            }
        }

        private void AddNegativeCrit(float addedCrit){
            if(Crit == 0f) return;
            if(Crit + addedCrit <= 0f){
                float remainder = - addedCrit - Crit;
                probabilities[0] = remainder;
                probabilities[1] -= addedCrit;
            }else{
                probabilities[0] += addedCrit;
                probabilities[1] -= addedCrit;
            }
        }

        public void AddFail(float addedFail){
            if(addedFail>=0){
                AddPositiveFail(addedFail);
            }else{
                AddNegativeFail(addedFail);
            }
        }

        private void AddPositiveFail(float addedFail){
            if(Fail + addedFail >= 100){
                probabilities[2] = 100.0f;
                probabilities[1] = 0;
                probabilities[0] = 0;
            }else{
                if(Normal == 0){
                    probabilities[2] += addedFail;
                    probabilities[0] -= addedFail;
                }else{
                    if(Normal-addedFail>=0){
                        probabilities[2] += addedFail;
                        probabilities[1] -= addedFail;
                    }else{
                        float remainder = addedFail - Normal;
                        probabilities[2] += addedFail;
                        probabilities[1] = 0;
                        probabilities[0] -= remainder;
                    }
                }
            }
        }

        private void AddNegativeFail(float addedFail){
            if(Fail == 0f) return;
            if(Fail + addedFail <= 0f){
                float remainder = - addedFail - Fail;
                probabilities[2] = remainder;
                probabilities[1] -= addedFail;
            }else{
                probabilities[2] += addedFail;
                probabilities[1] -= addedFail;
            }
        }

        public void Log(){
            Debug.Log("ShotResultProbs: " + Crit + "% / " + Normal + "% / " + Fail + "%");
        }
    }
}
