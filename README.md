# Data-Saving-JSON-Unity
 JSON (JavaScript Object Notation) is a lightweight data interchange format that's easy for humans to read and write and easy for machines to parse and generate.     
 Unity provides built-in support for JSON through the JsonUtility class, and you can also use third-party libraries like Newtonsoft.Json ("com.unity.nuget.newtonsoft-json": "3.2.1")

**JSON object**   
refers to the representation of a JSON data structure that consists of key-value pairs. 
A JSON object is represented using curly braces {}. Inside the curly braces, key-value pairs are separated by commas. 
 {"Name":"sadia","level":"1","health":"100"}

 **Serialization**     
The process of converting an object into a string or byte format that can be easily stored or transmitted.
Formats: Common formats include JSON, XML, and binary.

**Deserialization**
converts a serialized string or byte data back into an object or data structure.

<img width="333" alt="Screenshot 2024-08-20 at 12 26 02 PM" src="https://github.com/user-attachments/assets/99c86fe9-1545-4a8a-be8c-ac53f90887b3">

**GameData.cs**
```
public class GameData 
{
    public string Name { get; set; }
    public string level { get; set; }
    public string health { get; set; }

    public GameData()
    {
        Name = "null";
        level = "0";
        health = "0";
    }
}
```
**GameStaticData.cs**
```
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
```
**SaveLoadSystem.cs**
```
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
```
**GameManager.cs**
```
public class GameManager : MonoBehaviour
{
   
    public UIManager uiManager;

    private void Awake()
    {
        uiManager.SetAllUI(GameStaticData.LoadGameData());
    }

    public void SaveThroughJson()
    {
        GameStaticData._name = uiManager.userNameInputField.text;
        GameStaticData._level = uiManager.levelInputField.text;
        GameStaticData._health = uiManager.healthInputField.text; ;
        GameStaticData.SaveGameData();
        uiManager.SetAllUI(GameStaticData.LoadGameData());
    }
}
```
**UIManager.cs**
```
public class UIManager : MonoBehaviour
{
    public TMP_InputField userNameInputField;
    public TMP_InputField levelInputField;
    public TMP_InputField healthInputField;

    [Space]

    public TMP_Text m_userNameText;
    public TMP_Text m_levelText;
    public TMP_Text m_healthText;

    public void SetAllUI(GameData playerProfile)
    {
        m_userNameText.text ="Name : "+ playerProfile.Name;
        m_healthText.text = "Health : "+playerProfile.health;
        m_levelText.text = "Level : "+playerProfile.level;
     
    }
}
```
