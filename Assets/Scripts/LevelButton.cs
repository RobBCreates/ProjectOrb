using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField]
    private Text nameText = null;

    public string buttonName = "";

    private void Awake()
    {
        for(int i = 0; i < 2; i++)
        {
            char currentLetter = gameObject.transform.name[2 + i];
            buttonName = buttonName + currentLetter.ToString();
        }
       
        nameText.text = buttonName;
    }


    public void LevelButtonPressed(string buttonName)
    {
        if(MainMenuManager.Instance)
        {
            // Pass the name of the button to the Manager so it can deconstruct this for the World/Level info.
            // Buttons should be spawned dynamically and named using the convention W#L#
            MainMenuManager.Instance.SetWorldAndLevel(gameObject.transform.name);
        }
        else
        {
            Debug.LogWarning("Main Menu Manager needed in Main Menu");
        }
    }
}
