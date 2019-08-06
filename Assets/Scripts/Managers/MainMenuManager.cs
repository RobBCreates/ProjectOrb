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

    public void ButtonPlayPressed()
    {
        HideAllCanvas();
        levelButtonsCanvas.SetActive(true);
        
    }

    public void ButtonInfoPressed()
    {
        infoText.SetActive(!infoText.activeSelf);
        settingsCanvas.SetActive(false);
    }

    public void ButtonSettingsPressed()
    {
        settingsCanvas.SetActive(!settingsCanvas.activeSelf);
        infoText.SetActive(false);
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

    public void SetWorld(int world)
    {
        if (PersistentManager.Instance)
        {
            PersistentManager.Instance.SetWorld(world);
            SceneManager.LoadScene("Main");
        }
        else
        {
            Debug.LogWarning("PersistentManagerNeeded");
        }
    }

    public void SetWorldAndLevel(string buttonName)
    {
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
