using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabState : MonoBehaviour
{
    public Button button; 
    public Sprite pressedSprite;
    public Sprite normalSprite;

    public Button [] tabs;
    
    // Start is called before the first frame update
    void Start()
    {
        button.image.sprite = pressedSprite;
    }

    // Update is called once per frame
    void Update()
    {
        button.onClick.AddListener(() => TabActive());
    }

    void TabActive()
    {
        button.image.sprite = pressedSprite;

        for (int i = 0; i < tabs.Length; i++)
        {
            tabs[i].onClick.AddListener(Close);
        }
    }

    public void Close()
    {
        button.image.sprite = normalSprite;
        
    }
}
