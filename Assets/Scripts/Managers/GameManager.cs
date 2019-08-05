using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }

    private int levelCollectableCount;
    private float startTime;
    private float levelTime;

    [HideInInspector]
    public bool isPlaying = false;


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

        Initialise();
    }

    void Initialise()
    {
        //levelCollectableCount = FindObjectsOfType(typeof(Collectable)).Length;
    }

    public void CollectableDestroyed()
    {
        levelCollectableCount--;
        if (levelCollectableCount == 0)
        {
            isPlaying = false;
            levelTime = Time.time - startTime;
            // Level over - Success
            GameCanvasManager.Instance.ShowLevelOver(levelTime);
        }
    }

    public void StartPlay()
    {
        levelCollectableCount = FindObjectsOfType(typeof(Collectable)).Length;
        startTime = Time.time;
        isPlaying = true;

    }

    public void PlayerDied()
    {
        // Level over - Failed
        if (!isPlaying)
            return;

        isPlaying = false;
        GameCanvasManager.Instance.ShowLevelOver(0);
    }

    public void PlayVibrate()
    {
        if (!PersistentManager.Instance)
        {
            Debug.LogWarning("PersistentManager needed!");
            return;
        }

        if (PersistentManager.Instance.GetVibrate())
        {
#if UNITY_ANDROID
            Handheld.Vibrate();
#endif
        }
    }

}
