using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
     

    /*public void QuitGame()
    {
        Application.Quit();
    }*/

    public void QuitGame()
    {
       #if UNITY_EDITOR
       UnityEditor.EditorApplication.isPlaying = false;
       #endif
       Application.Quit();
    }
    
}
