using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEngine
{
    public class EasyAIBehavior : AIBehavior
    {
        public EasyAIBehavior(MatchEventReader reader) : base(reader) { }

        protected override void OnNewSet()
        {
            int whichPlaystyle = Random.Range(0,3);
            playerMatchInstance.SetCurrentPlaystyle(whichPlaystyle);
            reader.OnPlaystyleChanged(1);
            Debug.Log("AI changing playstyle : " + playerMatchInstance.GetCurrentPlaystyle().id);

        }
    }
}
