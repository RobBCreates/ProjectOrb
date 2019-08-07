using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSelectManager : MonoBehaviour
{

    [SerializeField]
    private Button nextWorldButton = null;
    [SerializeField]
    private Button PreviousWorldButton = null;
    [SerializeField]
    private List<GameObject> availableWorldCanvas = new List<GameObject>();

    private int currentWorld = 0;

    private void Awake()
    {
        currentWorld = 0;

        CheckAvailableWorlds();
    }


    private void CheckAvailableWorlds()
    {
        if(currentWorld == 0)
        {
            PreviousWorldButton.interactable = false;
            nextWorldButton.interactable = true;
            // PreviousWorldButton.SetActive(false);
            // nextWorldButton.SetActive(true);
        }
        else if(currentWorld == availableWorldCanvas.Count -1)
        {
            PreviousWorldButton.interactable = true;
            nextWorldButton.interactable = false;
            currentWorld = availableWorldCanvas.Count -1;

            //PreviousWorldButton.SetActive(true);
            //nextWorldButton.SetActive(false);
        }
        else
        {
            PreviousWorldButton.interactable = true;
            nextWorldButton.interactable = true;

            //PreviousWorldButton.SetActive(true);
            //nextWorldButton.SetActive(true);
        }
    }

    public void ButtonPressedNextWorld()
    {
        availableWorldCanvas[currentWorld].SetActive(false);
        currentWorld++;
        availableWorldCanvas[currentWorld].SetActive(true);
        CheckAvailableWorlds();
    }

    public void ButtonPressedPreviousWorld()
    {
        availableWorldCanvas[currentWorld].SetActive(false);
        currentWorld--;
        availableWorldCanvas[currentWorld].SetActive(true);
        CheckAvailableWorlds();
    }

}
