using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DrillEffect
{
    public enum DrillEffectName{
        IMPROVE_STRENGTH,
        IMPROVE_SPEED,
        IMPROVE_REFLEXES,
        IMPROVE_INTELLIGENCE,
        IMPROVE_DEXTERITY,
        IMPROVE_ENDURANCE
    }
    public DrillEffectName id;
    public float effect;

    public DrillEffect(DrillEffectName name, float effect){
        id = name;
        this.effect = effect;
    }

    public void Apply(ref PlayerStats stats){
        switch(id){
            case DrillEffectName.IMPROVE_STRENGTH:
                stats.ImproveStrength(effect);
            break;
            case DrillEffectName.IMPROVE_SPEED:
                stats.ImproveSpeed(effect);
            break;
            case DrillEffectName.IMPROVE_REFLEXES:
                stats.ImproveReflexes(effect);
            break;
            case DrillEffectName.IMPROVE_INTELLIGENCE:
                stats.ImproveIntelligence(effect);
            break;
            case DrillEffectName.IMPROVE_DEXTERITY:
                stats.ImproveDexterity(effect);
            break;
            case DrillEffectName.IMPROVE_ENDURANCE:
                stats.ImproveEndurance(effect);
            break;
        }
    }
}
