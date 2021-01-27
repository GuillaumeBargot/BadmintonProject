using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GameEngine;

[CreateAssetMenu(fileName = "UIEventReader", menuName = "Events/UIEventReader")]
public class MatchUIEventReader : ScriptableObject
{
    public event UnityAction<int> playstyleChangedEvent;
    public event UnityAction<Advantage> advantageUpdatedEvent;
    public event UnityAction advantageResetEvent;
    public event UnityAction<int> critEvent;

    public event UnityAction<ScoreRecap> scoreChanged;

    public void OnPlaystyleChanged(int player){
        playstyleChangedEvent.Invoke(player);
    }

    public void OnAdvantageUpdated(Advantage advantage){
        advantageUpdatedEvent.Invoke(advantage);
    }

    public void OnAdvantageReset(){
        advantageResetEvent.Invoke();
    }

    public void OnCritEvent(int player){
        critEvent.Invoke(player);
    }

    public void OnScoreChanged(ScoreRecap scoreRecap){
        scoreChanged.Invoke(scoreRecap);
    }
}
