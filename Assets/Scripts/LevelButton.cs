using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    


    public void LevelButtonPressed(string buttonName)
    {
        if(MainMenuManager.Instance)
        {
            MainMenuManager.Instance.SetWorldAndLevel(gameObject.transform.name);
        }
        else
        {
            Debug.LogWarning("Main Menu Manager needed in Main Menu");
        }
    }
}
