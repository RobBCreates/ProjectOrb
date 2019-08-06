using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private bool bMainMenuPlayer = false;

    [SerializeField]
    private float moveSpeed = 0;
    [SerializeField]
    private float rotationSpeed = 0;

    private int startDirection = 1;
    private int direction = -1;


    public void SetStartDirection(int startDir)
    {
        startDirection = startDir;
        
        if(startDir == 1)
        {
            gameObject.transform.rotation = Quaternion.Euler(0,0,90);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0,0,-90);
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Skip move input if we're on main menu.
        if(bMainMenuPlayer) 
        {
            transform.position += transform.up * Time.deltaTime * moveSpeed;
            transform.Rotate(0, 0, direction * rotationSpeed * Time.deltaTime);

            return;
        }

        if (GameManager.Instance.isPlaying)
        {
            if (Input.GetMouseButton(0))
            {
                direction = 1 * startDirection;
            }
            else
            {
                direction = -1 * startDirection;
            }


            transform.position += transform.up * Time.deltaTime * moveSpeed;
            transform.Rotate(0, 0, direction * rotationSpeed * Time.deltaTime);
        }

    }
}
