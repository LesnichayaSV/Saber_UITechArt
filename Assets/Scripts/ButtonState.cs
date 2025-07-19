using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonState : MonoBehaviour
{
    public Button button;

    public GameObject glow;
    
    public Button [] tabs;


    void Start()
    {
       button.onClick.AddListener(() => glow.SetActive(true));
      
    }

    
    void Update()
    {
       
       for (int i = 0; i < tabs.Length; i++)
        {
            tabs[i].onClick.AddListener(Close);
        }
    }

    public void Close()
    {
        glow.SetActive(false);
        
        
    }

    
}