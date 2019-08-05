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

        int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;

        for(int i = 0; i < sceneCount; i++)
        {
            scenes.Add(System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i)));

        }
        DontDestroyOnLoad(gameObject);
    }

    public void SetPlaySound(bool newPlaySound)
    {
        bPlaySound = newPlaySound;
    }

    public bool GetPlaySound()
    {
        return bPlaySound;
    }

    public void SetVibrate(bool newVibrate)
    {
        bVibrate = newVibrate;
    }

    public bool GetVibrate()
    {
        return bVibrate;
    }

    public void SetWorld(int world)
    {
        currentWorld = world;
    }

    public void SetWorldAndLevel(string selectedName)
    {
        string TestName = selectedName;

        testChar = TestName[1];
        currentWorld = int.Parse(testChar.ToString()); 
          
    }

    public int GetCurrentWorld()
    {
        // - 1 here so we can input the world we want to display to player and make 
        // it easier for designers to enter obvious values. 
        return currentWorld - 1;
    }


}
