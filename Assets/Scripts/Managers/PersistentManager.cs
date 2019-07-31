using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentManager : MonoBehaviour
{

    private static PersistentManager _instance;
    public static PersistentManager Instance{
        get {return _instance;}
    }

    private bool bPlaySound;
    private bool bVibrate;

    private void Awake()
    {
        if(!_instance)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
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

 
}
