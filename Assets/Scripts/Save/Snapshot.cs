using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Snapshot {
    public string coachName;

    public string currentPlayerName;

    public Snapshot(string coachName, string playerName){
        this.coachName = coachName;
        this.currentPlayerName = playerName;
    }
}
