using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;

[CreateAssetMenu(fileName = "SaveManager", menuName = "Save/SaveManager", order = 1)]
public class SaveManager : ScriptableObject
{
    private string SAVES_FOLDER;
    private string[] snapshotFiles;

    private int currentSave = -1;

    private void Awake() {
        SAVES_FOLDER = Application.persistentDataPath + "/saves/";
    }

    public void Save(){
        currentSave = SaveData.current.saveSlot;
        string persistentPath = Application.persistentDataPath;
        Task t = Task.Run(() => SerializationManager.SaveAsync(SaveData.current.saveSlot, SaveData.current.CreateSnapshot(), SaveData.current, persistentPath));
        t.Wait();
        //SerializationManager.Save(SaveData.current.saveSlot, SaveData.current.CreateSnapshot(), SaveData.current);
    }

    public void Load(int nbSave){
        SaveData.Load((SaveData)SerializationManager.LoadSave(nbSave));
        currentSave = nbSave;
    }

    public void Delete(int nbSave){
        SerializationManager.DeleteSave(nbSave);
        if(currentSave == nbSave){
            currentSave = -1;
        }
    }

    public void GetSnapshots(){
        if(!Directory.Exists(SAVES_FOLDER)){
            Directory.CreateDirectory(SAVES_FOLDER);
        }

        snapshotFiles = Directory.GetFiles(SAVES_FOLDER, "*.snap");
    }

    public int GetCurrentSave(){
        return currentSave;
    }
}
