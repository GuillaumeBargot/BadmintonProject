﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace GameEngine
{

    [CreateAssetMenu(fileName = "MatchEventReader", menuName = "Events/MatchEventReader")]
    public class MatchEventReader : ScriptableObject
    {
        public event UnityAction<int> playstyleChangedEvent;
        public event UnityAction<Advantage> advantageUpdatedEvent;
        public event UnityAction advantageResetEvent;
        public event UnityAction<int> critEvent;
        public event UnityAction<Score> scoreChangedEvent;

        public event UnityAction newSet;
        public event UnityAction<bool> pausedEvent;

        public event UnityAction matchOver;

        public void OnPlaystyleChanged(int player)
        {
            playstyleChangedEvent.Invoke(player);
        }

        public void OnAdvantageUpdated(Advantage advantage)
        {
            advantageUpdatedEvent.Invoke(advantage);
        }

        public void OnAdvantageReset()
        {
            advantageResetEvent.Invoke();
        }

        public void OnCritEvent(int player)
        {
            critEvent.Invoke(player);
        }

        public void OnScoreChanged(Score score)
        {
            scoreChangedEvent.Invoke(score);
        }

        public void OnPaused(bool paused)
        {
            pausedEvent.Invoke(paused);
        }

        public void OnNewSet(){
            newSet.Invoke();
        }

        public void OnMatchOver(){
            matchOver.Invoke();
        }
    }
}
