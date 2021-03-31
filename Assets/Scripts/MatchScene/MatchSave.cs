using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEngine;

[System.Serializable]
public class MatchSave
{
    public PlayerSave cpuPlayer;

    public Score score;
    public PointHistory pointHistory;

    public bool matchOver;

    public MatchSave(PlayerSave cpu){
        this.cpuPlayer = cpu;
        this.matchOver = false;
        this.pointHistory = new GameEngine.PointHistory();
        this.score = new Score(3);
    }
}
