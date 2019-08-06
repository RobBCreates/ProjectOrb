using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;

public class WorldManager : SerializedMonoBehaviour
{
    
    //private enum WorldEnum { One, Two, Three };
    //[SerializeField]
    //private WorldEnum currentWorld;
    
    [SerializeField]
    private string m_InputFile;

    [TableList]
    public List<Dictionary<string,object>> csvPoints;

    private int currentWorld;

    

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
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

        Tilemap[] gameObjects = Resources.FindObjectsOfTypeAll<Tilemap>();
        string hexString;
        foreach (Tilemap map in gameObjects)
        {
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
