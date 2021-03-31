using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tournament {
    public enum TournamentState{
        IDLE,
        MATCH,
        FINISHED

    };

    public TournamentState state;

    public MatchSave currentMatch = null;

    private List<MatchSave> doneMatches;

    private const int nbMatches = 3;



    public void CreateMatch(PlayerSave cpu){
        currentMatch = new MatchSave(cpu);
        doneMatches = new List<MatchSave>();
    }

    public Tournament(){
        state = TournamentState.IDLE;
    }

    public void Finish(){
        state = TournamentState.FINISHED;
    }

    public bool IsFinished(){
        return state==TournamentState.FINISHED;
    }

    public void StartCurrentMatch(){
        state = TournamentState.MATCH;
    }

    public void StartMatch(){
        state =  TournamentState.MATCH;
    }

    public void EndCurrentMatch(){
        state = TournamentState.IDLE;
        doneMatches.Add(currentMatch);
        if(doneMatches.Count >= nbMatches){
            currentMatch = null;
            state = TournamentState.FINISHED;
        }else{
            currentMatch = new MatchSave(PlayerSave.CreateRandomCPU());
        }
    }
}
