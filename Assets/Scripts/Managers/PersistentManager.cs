using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PersistentManager : MonoBehaviour
{

    private static PersistentManager _instance;
    public static PersistentManager Instance
    {
        get { return _instance; }
    }

    private int storedPlaySound = -1;
    private int storedVibrate = -1;
    private string storedPlaySoundName = "PlaySound";
    private string storedVibrateName = "Vibrate";

    private bool bPlaySound;
    private bool bVibrate;
    public int currentWorld;

    public List<string> scenes = new List<string>();

    public string TestName;
    public char testChar;

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

        // Store for use so we can dynamically create level buttons from scenes using
        // name convention W#L#
        StoreAllScenesInBuild();
        DontDestroyOnLoad(gameObject);



    }

    public bool HasSaveFile()
    {
        // Check any of the potential stored save names as they should all be stored together so if we have one Key we should have them all. 
        return PlayerPrefs.HasKey(storedPlaySoundName);
    }

    public void SaveSettings()
    {
        storedPlaySound = bPlaySound ? 1 : 0;
        storedVibrate = bVibrate ? 1 : 0;

        PlayerPrefs.SetInt(storedPlaySoundName, storedPlaySound);
        PlayerPrefs.SetInt(storedVibrateName, storedVibrate);
        Debug.Log(storedVibrate);
    }

   

    private void StoreAllScenesInBuild()
    {
        int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;

        for (int i = 0; i < sceneCount; i++)
        {
            scenes.Add(System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i)));
        }
    }

    public void SetPlaySound(bool newPlaySound)
    {
        bPlaySound = newPlaySound;
    }

    public bool GetPlaySound()
    {
        bPlaySound = (PlayerPrefs.GetInt(storedPlaySoundName) == 1) ? true : false; 
        return bPlaySound;
    }

    public void SetVibrate(bool newVibrate)
    {
     
        bVibrate = newVibrate;
    }

    public bool GetVibrate()
    {
        bVibrate = (PlayerPrefs.GetInt(storedVibrateName) == 1) ? true : false;
        return bVibrate;
    }

    public void SetWorld(int world)
    {
        currentWorld = world;
    }

    public void SetWorldAndLevel(string selectedName)
    {
        // Get the second value of the scene name which will provide the chosen
        // world. 
        testChar = selectedName[1];
        currentWorld = int.Parse(testChar.ToString()); 
          
    }

    public int GetCurrentWorld()
    {
        // - 1 here so we can input the world we want to display to player and make 
        // it easier for designers to enter obvious values. 
        return currentWorld - 1;
    }


}
