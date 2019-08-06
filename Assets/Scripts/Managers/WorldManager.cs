using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;

public class WorldManager : SerializedMonoBehaviour
{
        
    [SerializeField]
    private string m_InputFile;

    [TableList]
    public List<Dictionary<string,object>> csvPoints;

    private int currentWorld;

    void Awake()
    {
        if(PersistentManager.Instance)
        {
            currentWorld = PersistentManager.Instance.GetCurrentWorld();
        }
        else
        {
            Debug.LogWarning("Persistent Manager needed in ALL Levels");
        }
        csvPoints = CSVReader.Read(m_InputFile);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get the tilemap in the level. 
        Tilemap[] gameObjects = Resources.FindObjectsOfTypeAll<Tilemap>();
        string hexString;
        foreach (Tilemap map in gameObjects)
        {
            // Check for different parts of the tilemap and set the colours based on which part we've found. 
            switch (map.gameObject.name)
            {
                case "Floor":
                    Color tempFloorCol;
                    hexString = csvPoints[currentWorld]["Floor"].ToString();
                    if(ColorUtility.TryParseHtmlString(hexString, out tempFloorCol))
                    map.color = tempFloorCol;
                    break;
                case "Wall":
                    Color tempWallColour;
                    hexString = csvPoints[currentWorld]["Wall"].ToString();
                    if(ColorUtility.TryParseHtmlString(hexString, out tempWallColour))
                    map.color = tempWallColour;
                    break;
                default:
                    break;
            }

        }

    }

}
