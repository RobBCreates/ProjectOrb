using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartInputDetector : MonoBehaviour
{

    [SerializeField]
    private GameObject arrowHolder = null;
    [SerializeField]
    private SpriteRenderer leftArrow = null;
    [SerializeField]
    private SpriteRenderer rightArrow = null;

    [SerializeField]
    private Color selectedColour = Color.white;
    [SerializeField]
    private Color deselectedColour = Color.white;

    private int startDir;
    private void Start()
    {
        leftArrow.color = deselectedColour;
        rightArrow.color = selectedColour;
    }

    // Update is called once per frame
    void Update()
    {
        // get finger location and decide whether the player Orb will be moving left or right.
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.point.x <= 0)
            {
                leftArrow.color = selectedColour;
                rightArrow.color = deselectedColour;
                startDir = 1;
            }
            else
            {
                leftArrow.color = deselectedColour;
                rightArrow.color = selectedColour;
                startDir = -1;
            }
        }
    }


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
