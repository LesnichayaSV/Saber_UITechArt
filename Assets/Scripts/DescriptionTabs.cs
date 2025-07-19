using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionTabs : MonoBehaviour
{
    public Button gameplayButton;
    public Button videoButton;

    public Sprite pressedSprite;
    public Sprite normalSprite;

    public GameObject Gameplay_tab;
    public GameObject Video_tab;

    public Animator animator_GT;
    public Animator animator_VT;
    
    
   
    
    void Start()
    {
        videoButton.image.sprite = normalSprite;  
        gameplayButton.image.sprite = pressedSprite;

        Gameplay_tab.SetActive(true);
        Video_tab.SetActive(false);   

        animator_GT = Gameplay_tab.GetComponent<Animator>();   
        animator_VT = Video_tab.GetComponent<Animator>();

        gameplayButton.onClick.AddListener(GameplayOpen);
        videoButton.onClick.AddListener(VideoOpen);
    }
   
    
    void GameplayOpen()
    {
        Gameplay_tab.SetActive(true);
        Video_tab.SetActive(false);
        
        animator_GT.enabled = true;
        animator_VT.enabled = false;
        
        animator_GT.Play("GameplayOpen_animation");
        
        videoButton.image.sprite = normalSprite;
        gameplayButton.image.sprite = pressedSprite;
    }


    void VideoOpen()
    {
        Video_tab.SetActive(true);
        Gameplay_tab.SetActive(false);
        
        animator_GT.enabled = false;
        animator_VT.enabled = true;

        animator_VT.Play("VideoOpen_animation");
              
        gameplayButton.image.sprite = normalSprite;
        videoButton.image.sprite = pressedSprite;
    }

    private void OnDestroy()
    {
        gameplayButton.onClick.RemoveAllListeners();
        gameplayButton.onClick.AddListener(GameplayOpen);      
    }



}
