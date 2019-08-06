// --** This class is only really intended for in Editor use. It allows the user to spawn collectables around a circle. **--\\
// --** The Radius in here should be roughly the player Rotation speed divided by the player speed. Then halved. This provides a circle that fits the complete arc of the player moving 
// when nothing is pressed. So RotSpeed / MoveSpeed / 2 = Radius. **-- \\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CollectorSpawner : MonoBehaviour
{
    public float radius;
    public int numObjects;
    public GameObject Collectable;

    private List<GameObject> lastSpawned = new List<GameObject>();
    public List<GameObject> allCollectables = new List<GameObject>();

    // Editor visual stuff.
    public int vertCount = 40;
    public float lineWidth = 1f;
    private LineRenderer lineRenderer;

    public void SpawnCollectables()
    {
        lastSpawned.Clear();

        for (int i = 0; i < numObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numObjects;
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            Vector3 pos = transform.position + new Vector3(x, y, 0);
            lastSpawned.Add(Instantiate(Collectable, pos, Quaternion.identity));

        }

        foreach (GameObject last in lastSpawned)
        {
            allCollectables.Add(last);
        }
    }

    public void DestroyLastSpawned()
    {
        foreach (GameObject obj in lastSpawned)
        {
            DestroyImmediate(obj);
        }

        lastSpawned.Clear();
    }

    public void DestroyAll()
    {

        foreach (GameObject obj in allCollectables)
        {
            DestroyImmediate(obj);
        }
        lastSpawned.Clear();
        allCollectables.Clear();


    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected() 
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.widthMultiplier = lineWidth;

        float deltaTheta = (2f * Mathf.PI) / vertCount;
        float theta = 0f;

        Vector3 oldPos = Vector3.zero;
        for (int i = 0; i < vertCount + 1; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f);
            Gizmos.DrawLine(oldPos, transform.position + pos);
            oldPos = transform.position + pos;
            theta += deltaTheta;
        }
    }
#endif

    private void Start()
    {
        // Test implementation of spawning at random points around a circle in case this becomes useful. 

        // Vector3 center = transform.position;
        // for (int i = 0; i < numObjects; i++)
        // {
        //     Vector3 pos = RandomCircle(center, radius);
        //     Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
        //     Instantiate(Collectable, pos, Quaternion.identity);
        // }

        // for (int i = 0; i < 8; i++)
        // {
        //     float angle = i * Mathf.PI * 2f / 8;
        //     Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius + gameObject.transform.position.x, Mathf.Sin(angle) * radius + gameObject.transform.position.y, gameObject.transform.position.z);
        //     GameObject go = Instantiate(Collectable, newPos, Quaternion.identity);
        // }
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
