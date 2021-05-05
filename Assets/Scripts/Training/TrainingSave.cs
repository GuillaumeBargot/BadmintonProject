using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrainingSave {

    public TrainingSession currentTrainingSession;
    public List<string> ownedDrillIds;

    public TrainingSave(){
        currentTrainingSession = new TrainingSession();
        ownedDrillIds = new List<string>(){"BasicStrength", "BasicSpeed", "BasicReflexes", "BasicEndurance", "BasicIntelligence", "BasicDexterity"};
    }
}
