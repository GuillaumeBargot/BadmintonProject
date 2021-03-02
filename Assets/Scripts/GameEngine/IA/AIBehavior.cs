using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEngine;

public abstract class AIBehavior
{
    protected PlayerMatchInstance playerMatchInstance{
        get{
            return MatchEngine.Instance.GetCPU();
        }
    }

    protected MatchEventReader reader;

    public AIBehavior(MatchEventReader reader){
        this.reader = reader;
        reader.newSet += OnNewSet;
    }

    protected abstract void OnNewSet();

    public void OnDestroy() {
        reader.newSet -= OnNewSet;
    }
}
