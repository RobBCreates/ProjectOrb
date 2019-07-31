using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollect : MonoBehaviour
{

    public float radius;
    public int numObjects;
    public GameObject Collectable;


    // Start is called before the first frame update
    void Start()
    {

        Vector3 center = transform.position;
        for (int i = 0; i < numObjects; i++)
        {
            Vector3 pos = RandomCircle(center, radius);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            Instantiate(Collectable, pos, Quaternion.identity);
        }

        // for (int i = 0; i < 8; i++)
        // {
        //     float angle = i * Mathf.PI * 2f / 8;
        //     Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius + gameObject.transform.position.x, Mathf.Sin(angle) * radius + gameObject.transform.position.y, gameObject.transform.position.z);
        //     GameObject go = Instantiate(Collectable, newPos, Quaternion.identity);
        // }
    }

    // Update is called once per frame
    void Update()
    {

    }



    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
}
