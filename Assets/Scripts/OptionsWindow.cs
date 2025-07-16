using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsWindow : MonoBehaviour
{
    public GameObject OptionsBlock;
    public GameObject Gameplay_tab;
     
    public Button button; 
    public Sprite pressedSprite;
    public Sprite normalSprite;   

    public Animator animator;
    public Button [] tabs;

    
    void Start()
    {
        animator = OptionsBlock.GetComponent<Animator>();
        button.image.sprite = normalSprite;
               
    }
    
    
    void Update()
    {
        button.onClick.AddListener(() => OptionsBlockOpen());
        
    }

    void OptionsBlockOpen()
    {
        OptionsBlock.SetActive(true);
        animator.Play("OpenWindow_animation");
       
        button.image.sprite = pressedSprite;
        
        
        for (int i = 0; i < tabs.Length; i++)
        {
            tabs[i].onClick.AddListener(Close);
        }
    }

    public void Close()
    {
        OptionsBlock.SetActive(false);
        button.image.sprite = normalSprite;
    }

    private void OnDestroy()
    {
        button.onClick.RemoveAllListeners();        
    }
}
