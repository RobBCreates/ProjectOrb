using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuManager : MonoBehaviour
{
    private static MainMenuManager _instance;

    public static MainMenuManager Instance
    {
        get { return _instance; }
    }

    [SerializeField]
    GameObject canvasInfo = null;
    [SerializeField]
    GameObject settingsCanvas = null;
    [SerializeField]
    GameObject canvasWorldLevels = null;
    [SerializeField]
    GameObject canvasWorld = null;
    [SerializeField]
    private Toggle soundToggle = null;
    [SerializeField]
    private Toggle vibrateToggle = null;
    [SerializeField]
    private GameObject playerObejct = null;
    [SerializeField]
    private List<GameObject> worldCanvasList = new List<GameObject>();

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
            if (!PersistentManager.Instance.HasSaveFile())
            {
                // No Save file yet so create one now and default everything to true to match visuals in game on first load.
                PersistentManager.Instance.SetPlaySound(bPlaySound);
                PersistentManager.Instance.SetVibrate(bPlayVibrate);
                // Default values stored so create our default save file.
                PersistentManager.Instance.SaveSettings();                                
            }
            else
            {
                // Set toggle buttons to reflect the stored player preferences. 
                soundToggle.isOn = PersistentManager.Instance.GetPlaySound();
                vibrateToggle.isOn = PersistentManager.Instance.GetVibrate();
            }
          
        }
    }

    private void HideAllCanvas()
    {
        canvasWorldLevels.SetActive(false);
        canvasInfo.SetActive(false);
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
        canvasWorldLevels.SetActive(true);
        playerObejct.SetActive(false);
    }

    public void ButtonPressedCloseSpecificCanvas(GameObject canvas)
    {
        canvas.SetActive(false);
        playerObejct.SetActive(true);
    }

    public void ButtonPressedCloseWorldCanvas()
    {
        if(canvasWorld.activeSelf == true)
        {
            canvasWorldLevels.SetActive(false);
            playerObejct.SetActive(true);
        }
        else
        {
            foreach(GameObject can in worldCanvasList)
            {
                can.SetActive(false);
            }
            canvasWorld.SetActive(true);
        }
    }

    public void ButtonPressedWorldSelected(int world)
    {
        canvasWorld.SetActive(false);
        worldCanvasList[world - 1].SetActive(true);
    }

    public void ButtonInfoPressed()
    {
        //ManageCanvasObject(canvasInfo);
        canvasInfo.SetActive(true);
        playerObejct.SetActive(false);
    }

    public void ButtonSettingsPressed()
    {
        ManageCanvasObject(settingsCanvas);
        playerObejct.SetActive(false);
    }

    public void ToggleSoundPressed(bool playSound)
    {
        if (PersistentManager.Instance)
        {
            PersistentManager.Instance.SetPlaySound(playSound);
            PersistentManager.Instance.SaveSettings();
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
            PersistentManager.Instance.SaveSettings();
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
