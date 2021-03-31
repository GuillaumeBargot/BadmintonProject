using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;

[CreateAssetMenu(fileName = "SaveManager", menuName = "Save/SaveManager", order = 1)]
public class SaveManager : ScriptableObject
{
    private static string CURRENT_SAVE_KEY = "currentSave";
    private string SAVES_FOLDER;
    private string[] snapshotFiles;

    private int currentSave = -1;

    private void Awake() {
        SAVES_FOLDER = Application.persistentDataPath + "/saves/";
        LoadPreferenceCurrentSave();
    }

    public void Save(){
        ChangeCurrentSave(SaveData.current.saveSlot);
        string persistentPath = Application.persistentDataPath;
        Task t = Task.Run(() => SerializationManager.SaveAsync(SaveData.current.saveSlot, SaveData.current.CreateSnapshot(), SaveData.current, persistentPath));
        t.Wait();
        //SerializationManager.Save(SaveData.current.saveSlot, SaveData.current.CreateSnapshot(), SaveData.current);
    }

    public void Load(int nbSave){
        SaveData.Load((SaveData)SerializationManager.LoadSave(nbSave));
        ChangeCurrentSave(nbSave);
    }

    public void Delete(int nbSave){
        SerializationManager.DeleteSave(nbSave);
        CheckIfDeleteCurrentSave(nbSave);
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

    private void LoadPreferenceCurrentSave(){
        currentSave = PlayerPrefs.GetInt(CURRENT_SAVE_KEY, -1);
    }

    private void SavePreferenceCurrentSave(){
        PlayerPrefs.SetInt(CURRENT_SAVE_KEY, currentSave);
        PlayerPrefs.Save();
    }

    private void ChangeCurrentSave(int save){
        currentSave = save;
        SavePreferenceCurrentSave();
    }

    private void CheckIfDeleteCurrentSave(int nbSave){
        if(currentSave == nbSave){
            ChangeCurrentSave(-1);
        }
    }
}
