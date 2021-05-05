using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Drill", menuName = "Training/Drill", order = 1)]
public class Drill : ScriptableObjectWithID
{
    public enum DrillType{
        STRENGTH,
        SPEED,
        REFLEXES,
        INTELLIGENCE,
        DEXTERITY,
        ENDURANCE
    }
    [SerializeField]
    private DrillType type;
    [SerializeField]
    private List<DrillEffect> baseEffects;

    public string Id{
        get{
            return id;
        }
    }

    public DrillType Type{
        get{
            return type;
        }
    }

    public List<DrillEffect> GetEffects(){
        return baseEffects;
    }
}
