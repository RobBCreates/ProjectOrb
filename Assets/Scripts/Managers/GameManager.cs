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
        // StartPlay called when player first taps the screen to launch the Orb. 

        // Get all collectables in the level to track the objective to hit before level completed.
        levelCollectableCount = FindObjectsOfType(typeof(Collectable)).Length;
        // Track start time for use when displaying complete play time at the end.
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
#if UNITY_ANDROID
        if (!PersistentManager.Instance)
        {
            Debug.LogWarning("PersistentManager needed!");
            return;
        }

        if (PersistentManager.Instance.GetVibrate())
        {

            Handheld.Vibrate();

        }
#endif
    }
}



