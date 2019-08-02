using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
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
        if(PersistentManager.Instance)
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

}
