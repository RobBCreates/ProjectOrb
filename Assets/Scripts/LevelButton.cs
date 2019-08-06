using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    


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
