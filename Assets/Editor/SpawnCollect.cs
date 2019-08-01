
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CollectorSpawner))]
public class CollectorSpawnEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CollectorSpawner spawner = (CollectorSpawner)target;

        if (GUILayout.Button("Spawn Collectables"))
        {
            spawner.SpawnCollectables();
        }

        if(GUILayout.Button("Undo Last Spawn"))
        {
            spawner.DestroyLastSpawned();
        }

        if(GUILayout.Button("Destroy ALL Collectables"))
        {
            spawner.DestroyAll();
        }
    }
}
