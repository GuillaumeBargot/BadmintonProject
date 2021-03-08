using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    private string SAVES_FOLDER;
    private string[] snapshotFiles;

    private void Awake() {
        SAVES_FOLDER = Application.persistentDataPath + "/saves/";
    }

    public void OnSave(int saveNumber){
        SerializationManager.Save(saveNumber, SaveData.current.CreateSnapshot(), SaveData.current);
    }

    public void GetSnapshots(){
        if(!Directory.Exists(SAVES_FOLDER)){
            Directory.CreateDirectory(SAVES_FOLDER);
        }

        snapshotFiles = Directory.GetFiles(SAVES_FOLDER, "*.snap");
    }
}
