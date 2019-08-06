using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private static MainMenuManager _instance;

    public static MainMenuManager Instance
    {
        get { return _instance; }
    }

    [SerializeField]
    GameObject infoText;
    [SerializeField]
    GameObject settingsCanvas;
    [SerializeField]
    GameObject levelButtonsCanvas;

    private bool bPlaySound = true;
    private bool bPlayVibrate = true;
    
    private void Awake()
    {
        if (!_instance)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (PersistentManager.Instance)
        {
            // Set player chosen settings through PersistentManager if it exists.
            // Which it ALWAYS should. 
            PersistentManager.Instance.SetPlaySound(bPlaySound);
            PersistentManager.Instance.SetVibrate(bPlayVibrate);
        }
    }

    private void HideAllCanvas()
    {
        levelButtonsCanvas.SetActive(false);
        infoText.SetActive(false);
        settingsCanvas.SetActive(false);
    }

    private void ManageCanvasObject(GameObject canvasObject)
    {
        // Check current active state of the canvas related to the pressed
        // button. Toggle if Active and always HideAllCanvas to avoid UI overlaps. 
        if (canvasObject.activeSelf)
        {
            HideAllCanvas();
        }
        else
        {
            HideAllCanvas();
            canvasObject.SetActive(true);
        }
    }

    public void ButtonPlayPressed()
    {
        ManageCanvasObject(levelButtonsCanvas);
    }

    public void ButtonInfoPressed()
    {
        ManageCanvasObject(infoText);
    }

    public void ButtonSettingsPressed()
    {
        ManageCanvasObject(settingsCanvas);
    }

    public void ToggleSoundPressed(bool playSound)
    {
        if (PersistentManager.Instance)
        {
            PersistentManager.Instance.SetPlaySound(playSound);
        }
        else
        {
            Debug.LogWarning("PersistentManagerNeeded");
        }
    }
    public void ToggleVibratePressed(bool vibrate)
    {
        if (PersistentManager.Instance)
        {
            PersistentManager.Instance.SetVibrate(vibrate);
        }
        else
        {
            Debug.LogWarning("PersistentManagerNeeded");
        }
    }

    public void SetWorldAndLevel(string buttonName)
    {
        // Called from LevelButton when pressed and breaks the string name 
        // down in the PersistentManager for use with the stored CSV colours. 
        if (PersistentManager.Instance)
        {
            PersistentManager.Instance.SetWorldAndLevel(buttonName);
            SceneManager.LoadScene(buttonName);
        }
        else
        {
            Debug.LogWarning("PersistentManagerNeeded");
        }
    }

}
