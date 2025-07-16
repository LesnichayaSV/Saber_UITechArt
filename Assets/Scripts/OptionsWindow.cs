using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsWindow : MonoBehaviour
{
    public GameObject OptionsBlock;    
    public Button button; 
    public Animator animator;


    void Start()
    {
        animator = OptionsBlock.GetComponent<Animator>();
    }
    
    
    void Update()
    {
        button.onClick.AddListener(() => OptionsBlock.SetActive(true));
        animator.Play("OpenWindow_animation");
        animator.StopPlayback();
    }

    private void OnDestroy()
    {
        button.onClick.RemoveAllListeners();        
    }
}
