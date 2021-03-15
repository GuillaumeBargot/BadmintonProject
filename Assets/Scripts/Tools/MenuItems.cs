using UnityEngine;
using UnityEditor;

public class MenuItems
{
    [MenuItem("Tools/Clear PlayerPrefs")]
    private static void ClearPrefOption()
    {
        PlayerPrefs.DeleteAll();
    }

    [MenuItem("Tools/Clear Saves")]
    private static void ClearSavesOption(){
        SerializationManager.DeleteSave(0);
        SerializationManager.DeleteSave(1);
        SerializationManager.DeleteSave(2);
    }
}
