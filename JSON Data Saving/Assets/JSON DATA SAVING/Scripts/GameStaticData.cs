using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStaticData
{
    public static string _name { get; set; }
    public static string _level { get; set; }
    public static string _health { get; set; }

    public static void SaveGameData()
    {
        var gameData = new GameData
        {
            health = _health,
            Name = _name,
            level = _level
        };

        SaveLoadSystem.SaveData(gameData);
    }

    public static GameData LoadGameData()
    {
        GameData gameData = SaveLoadSystem.GetData();
        _name = gameData.Name;
        _level = gameData.level;
        _health = gameData.health;
        return gameData;
    }
}
