using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Snapshot {
    public string coachName;

    public string currentPlayerName;

    public int currentMonth;

    public Snapshot(string coachName, string playerName, int currentMonth){
        this.coachName = coachName;
        this.currentPlayerName = playerName;
        this.currentMonth = currentMonth;
    }
}
