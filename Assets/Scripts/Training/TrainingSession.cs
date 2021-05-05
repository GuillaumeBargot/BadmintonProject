using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrainingSession
{
    private string[] session = new string[4]{null,null,null,null};

    public TrainingSession(){
        
    }
    public void SetupDrill(int index, string id){
        if(index<0 || index >3) return;
        session[index] = id;
    }

    public bool HasAllTrainingSetup(){
        return (session[0]!=null && session[1]!=null && session[2]!=null && session[3]!=null);
    }

    public void DeleteDrill(int index){
        if(index<0 || index >3) return;
        session[index] = null;
    }

    public string GetDrillName(int index){
        return session[index];
    }

    public List<DrillEffect> GetDrillEffects(){
        List<DrillEffect> toReturn = new List<DrillEffect>();
        Dictionary<DrillEffect.DrillEffectName, float> effectsDictionary = new Dictionary<DrillEffect.DrillEffectName, float>();
        List<Drill> drillObjects = GetSessionDrills();
        foreach(Drill drill in drillObjects){
            foreach(DrillEffect currentEffect in drill.GetEffects()){
                if(effectsDictionary.ContainsKey(currentEffect.id)){
                    effectsDictionary[currentEffect.id] += currentEffect.effect;
                }else{
                    effectsDictionary.Add(currentEffect.id, currentEffect.effect);
                }
            }
        }

        //Now that we have the complete Dictionary, let's put this back into a list of DrillEffect
        foreach(KeyValuePair<DrillEffect.DrillEffectName, float> entry in effectsDictionary){
            toReturn.Add(new DrillEffect(entry.Key, entry.Value));
        }
        return toReturn;
    }

    private List<Drill> GetSessionDrills(){
        List<Drill> toReturn = new List<Drill>();
        foreach(string name in session){
            Drill d = ScriptableObjectHelper.GetDrillWithId(name);
            if(d!=null){
                toReturn.Add(d);
            }
        }
        return toReturn;
    }

}
