using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   private static GameManager _instance; 
   public static GameManager Instance
    {
        get {return _instance;}
    }

    private int levelCollectableCount;
    public bool isPlaying = false; 

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

        Initialise();
    }

    void Initialise()
    {
        levelCollectableCount = FindObjectsOfType(typeof(Collectable)).Length;
    }

    public void CollectableDestroyed()
    {
        levelCollectableCount--;
        if(levelCollectableCount == 0)
        {
            // Level over
            
        }
    }

    public void StartPlay()
    {
        isPlaying = true;

    }

}
