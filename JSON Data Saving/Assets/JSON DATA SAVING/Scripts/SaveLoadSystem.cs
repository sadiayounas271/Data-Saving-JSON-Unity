using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class SaveLoadSystem 
{
    const string PlayerPrefKey = "GameData";

    public static GameData GetData()
    {
        if (PlayerPrefs.HasKey(PlayerPrefKey))
        {
            var jsonData = File.ReadAllText(Application.persistentDataPath + "GameData.json");
            // PlayerPrefs.GetString(PlayerPrefKey);
            return JsonConvert.DeserializeObject<GameData>(jsonData);
        }
        else
        {
            return new GameData();
        }
    }

    public static void SaveData(GameData gameData)
    {
        var jsonData = JsonConvert.SerializeObject(gameData);
        PlayerPrefs.SetString(PlayerPrefKey, jsonData);
        File.WriteAllText(Application.persistentDataPath + "GameData.json", jsonData);
    }    
}
