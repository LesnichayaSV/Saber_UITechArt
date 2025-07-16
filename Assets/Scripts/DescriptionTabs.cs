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
    
    
    void Start()
    {
        videoButton.image.sprite = normalSprite;  
        gameplayButton.image.sprite = pressedSprite;
        Gameplay_tab.SetActive(true);      
    }

    
    void Update()
    {
        gameplayButton.onClick.AddListener(() => GameplayOpen());

        videoButton.onClick.AddListener(() => VideoOpen());
    }

    void GameplayOpen()
    {
        Gameplay_tab.SetActive(true);
        gameplayButton.image.sprite = pressedSprite;

        Video_tab.SetActive(false);
        videoButton.image.sprite = normalSprite;
    }


    void VideoOpen()
    {
        Video_tab.SetActive(true);
        videoButton.image.sprite = pressedSprite;

        Gameplay_tab.SetActive(false);
        gameplayButton.image.sprite = normalSprite;
    }



}
