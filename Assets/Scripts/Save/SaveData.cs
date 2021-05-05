using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    private static SaveData _current;
    public static SaveData current
    {
        get
        {
            if (_current == null)
            {
                _current = new SaveData();
            }
            return _current;

        }
    }

    public int saveSlot;
    public HumanPlayerProfile profile;

    public PlayerSave playerSave;

    public Calendar calendar;

    public TrainingSave training;

    public static bool CurrentMatchExists{
        get{
            return current!=null && current.calendar!=null && current.calendar.GetTournament()!=null && current.calendar.GetTournament().currentMatch!=null;
        }
    }

    public static void NewGame(string coachName, int slot){
            SaveData.current.profile = new HumanPlayerProfile();
            SaveData.current.profile.playerName = coachName;
            SaveData.current.saveSlot = slot;
            SaveData.current.calendar = new Calendar();
            SaveData.current.training = new TrainingSave();
    }

    public Snapshot CreateSnapshot(){
        return new Snapshot(_current.profile.playerName, playerSave==null?"none":playerSave.name, calendar==null?-1:calendar.GetCurrentMonth());
    }

    public static void Load(SaveData saveData){
        _current = saveData;
    }

}
