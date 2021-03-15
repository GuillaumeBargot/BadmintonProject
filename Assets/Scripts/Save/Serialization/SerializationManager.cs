using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

public class SerializationManager
{

    public static bool Save(int saveNumber, object snapShotData, object saveData)
    {
        return SaveSnapshot(saveNumber, snapShotData) && SaveData(saveNumber, saveData);
    }

    private static bool SaveSnapshot(int saveNumber, object snapShotData)
    {
        return SaveObject(saveNumber, snapShotData, Application.persistentDataPath + "/saves", ".snap");
    }
    private static bool SaveData(int saveNumber, object saveData)
    {
        return SaveObject(saveNumber, saveData, Application.persistentDataPath + "/saves", ".save");
    }

    private static bool SaveObject(int saveNumber, object data, string path, string extension)
    {
        BinaryFormatter formatter = GetBinaryFormatter();

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        string finalPath = path + "/" + saveNumber + extension;

        FileStream file = File.Create(finalPath);
        formatter.Serialize(file, data);
        file.Close();

        return true;
    }

    public static object LoadSnapshot(int saveNumber)
    {
        return LoadObject(saveNumber, Application.persistentDataPath + "/saves", ".snap");
    }

    public static object LoadSave(int saveNumber)
    {
        return LoadObject(saveNumber, Application.persistentDataPath + "/saves", ".save");
    }

    public static void DeleteSave(int saveNumber)
    {
        DeleteObject(saveNumber, Application.persistentDataPath + "/saves", ".snap");
        DeleteObject(saveNumber, Application.persistentDataPath + "/saves", ".savews");
    }

    private static void DeleteObject(int saveNumber, string path, string extension)
    {
        string finalPath = path + "/" + saveNumber + extension;
        if (!File.Exists(finalPath))
        {
            //nothing
        }
        else
        {
            File.Delete(finalPath);
        }

    }

    private static object LoadObject(int saveNumber, string path, string extension)
    {
        string finalPath = path + "/" + saveNumber + extension;
        if (!File.Exists(finalPath))
        {
            return null;
        }

        BinaryFormatter formatter = GetBinaryFormatter();
        FileStream file = File.Open(finalPath, FileMode.Open);

        try
        {
            object save = formatter.Deserialize(file);
            file.Close();
            return save;
        }
        catch
        {
            Debug.LogErrorFormat("Failed to load file at {0}", path);
            file.Close();
            return null;
        }
    }

    private static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        return formatter;
    }



    // ------------------------------------------------------------------------
    //                          ASYNC
    // ------------------------------------------------------------------------

    public static async Task<bool> SaveAsync(int saveNumber, object snapShotData, object saveData, string persistentPath)
    {
        return await SaveSnapshotAsync(saveNumber, snapShotData, persistentPath) && await SaveDataAsync(saveNumber, saveData, persistentPath);
    }

    private static async Task<bool> SaveSnapshotAsync(int saveNumber, object snapShotData, string persistentPath)
    {
        return await SaveObjectAsync(saveNumber, snapShotData, persistentPath + "/saves", ".snap");
    }
    private static async Task<bool> SaveDataAsync(int saveNumber, object saveData, string persistentPath)
    {
        return await SaveObjectAsync(saveNumber, saveData, persistentPath + "/saves", ".save");
    }

    public static async Task<bool> SaveObjectAsync(int saveNumber, object data, string path, string extension)
    {
        BinaryFormatter formatter = GetBinaryFormatter();

        await Task.Run(() =>
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string finalPath = path + "/" + saveNumber + extension;

            FileStream file = File.Create(finalPath);
            formatter.Serialize(file, data);
            file.Close();
        });
        
        Debug.Log("ASYNC SAVE NICE MAN");

        return true;
    }
}
