using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private bool bMainMenuPlayer;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotationSpeed;

    private int startDirection = 1;
    private int direction = -1;

    // Start is called before the first frame update
    void Start()
    {

    }

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
