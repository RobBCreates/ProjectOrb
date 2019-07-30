using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCanvasManager : MonoBehaviour
{
   
   public void RestartPressed()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

}
