using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace GameEngine
{
    //This is the parent class for all probabilities (before called Tendencies or Chances). 
    //It rules everything that has a random number drawn into in the game
    public abstract class Probabilities<T>
    {
        protected float[] probabilities;

        protected T[] associatedResults;

        public Probabilities(float[] probabilities)
        {
            this.probabilities = probabilities;
            SetAssociatedResults();
        }

        protected abstract void SetAssociatedResults();

        public T Calculate()
        {
            int index = RandWithPercentages(probabilities);
            return associatedResults[index];
        }

        private bool CheckFor100()
        {
            return probabilities.Sum() == 100.0f;
        }


        //------------------------------------------------------------------------------------------------------------------
        //                                      HELPER METHODS
        //------------------------------------------------------------------------------------------------------------------

        protected static int RandWithPercentages(float[] percentages)
        {
            float rand = Maths.Rand100();
            float previousChancesSum = 0;
            for (int i = 0; i < percentages.Length; i++)
            {
                if (rand <= previousChancesSum + percentages[i])
                {
                    return i;
                }
                previousChancesSum += percentages[i];
            }
            return percentages.Length - 1;
        }

        protected static float[] MergeProbabilities(float[] tendencies1, float[] tendencies2)
        {   
            float[] resultingTendencies = tendencies1.Multiply(tendencies2);
            float resultSum = resultingTendencies.Sum();
            float multiplicator = 100f / resultSum;

            resultingTendencies.Multiply(multiplicator);
            return resultingTendencies;
        }
    }

}
