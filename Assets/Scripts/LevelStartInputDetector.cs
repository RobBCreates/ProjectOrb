using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartInputDetector : MonoBehaviour
{

    [SerializeField]
    private GameObject arrowHolder;
    [SerializeField]
    private SpriteRenderer leftArrow;
    [SerializeField]
    private SpriteRenderer rightArrow;

    [SerializeField]
    private Color selectedColour;
    [SerializeField]
    private Color deselectedColour;

    private int startDir;
    private void Start()
    {
        leftArrow.color = deselectedColour;
        rightArrow.color = selectedColour;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.point.x <= 0)
            {
                leftArrow.color = selectedColour;
                rightArrow.color = deselectedColour;
                startDir = -1;
            }
            else
            {
                leftArrow.color = deselectedColour;
                rightArrow.color = selectedColour;
                startDir = 1;
            }
        }
    }

    /// <summary>
    /// OnMouseUp is called when the user has released the mouse button.
    /// </summary>
    void OnMouseUp()
    {
        if(!GameManager.Instance.isPlaying)
        {
            Destroy(arrowHolder);
            PlayerMovement player = FindObjectsOfType<PlayerMovement>()[0];
            player.SetStartDirection(startDir);
            GameManager.Instance.StartPlay();
            Destroy(gameObject);
        }
    }
}
