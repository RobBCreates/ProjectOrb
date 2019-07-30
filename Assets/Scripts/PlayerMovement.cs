using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotationSpeed;

    private int direction = -1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }


        transform.position += transform.up * Time.deltaTime * moveSpeed;
        transform.Rotate(0, 0, direction * rotationSpeed * Time.deltaTime);
    }
}
