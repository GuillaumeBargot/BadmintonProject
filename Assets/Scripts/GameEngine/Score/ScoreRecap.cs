using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEngine
{

    public class ScoreRecap
    {
        public (int, int) sets;

        public (int, int) currentSet;

        public ScoreRecap((int, int) sets, (int, int) currentSet){
            this.sets = sets;
            this.currentSet = currentSet;
        }
    }

}
