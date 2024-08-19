using UnityEngine;

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
