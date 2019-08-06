using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCanvasManager : MonoBehaviour
{
   

   private static GameCanvasManager _instance; 
   public static GameCanvasManager Instance 
   {
      get {return _instance;}
   }

   [SerializeField]
   Text endText = null; 

   private void Awake()
   {
       if(!_instance)
       {
          _instance = this;
       }
       else
       {
          Destroy(gameObject);
       }
   }

   public void RestartPressed()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   public void ButtonPressedMainMenu()
   {
      SceneManager.LoadScene("Menu");
   }

   public void ShowLevelOver(float playTime)
   {
      // Player completed level with tracked time
      if(playTime != 0)
      {
         endText.text = "Level Complete In: " + playTime.ToString("f2");
      }
      // Player lost, no play time required
      else
      {
         endText.text = "Level Failed";
      }
   }

}
