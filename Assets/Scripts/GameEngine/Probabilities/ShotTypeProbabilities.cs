using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public class ShotTypeProbabilities : Probabilities<ShotType.Type>
    {
        //CONSTANTS
        private readonly static float[] BASE_PROBABILITIES = new float[]{40,20,10,30};

        // CONSTRUCTORS
        public ShotTypeProbabilities() : base (BASE_PROBABILITIES){}
        public ShotTypeProbabilities(float[] probabilities) : base(probabilities){}
        
        protected override void SetAssociatedResults(){
            associatedResults = new ShotType.Type[]{ShotType.Type.LONG, ShotType.Type.RUSH, ShotType.Type.SHORT,ShotType.Type.SMASH};
        }
    }
}
