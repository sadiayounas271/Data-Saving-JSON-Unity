using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
