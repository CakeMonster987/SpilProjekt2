using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
   public string levelName;
   public void press()
   {
      SceneManager.LoadScene(levelName);
   }
}
