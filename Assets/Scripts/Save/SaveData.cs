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

    public Snapshot CreateSnapshot(){
        return new Snapshot(_current.profile.playerName, playerSave==null?"none":playerSave.name, calendar==null?-1:calendar.GetCurrentMonth());
    }

    public static void Load(SaveData saveData){
        _current = saveData;
    }

}
