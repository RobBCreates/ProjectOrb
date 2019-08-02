using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PersistentManager : MonoBehaviour
{

    private static PersistentManager _instance;
    public static PersistentManager Instance
    {
        get { return _instance; }
    }

    private bool bPlaySound;
    private bool bVibrate;
    private int currentWorld;

    public List<string> scenes = new List<string>();

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

        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
            {
                string name = scene.path.Substring(scene.path.LastIndexOf('/') + 1);
                name = name.Substring(0, name.Length - 6);
                scenes.Add(name);

                //scenes.Add(scene.name);
            }
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

    public int GetCurrentWorld()
    {
        // - 1 here so we can input the world we want to display to player and make 
        // it easier for designers to enter obvious values. 
        return currentWorld - 1;
    }


}
