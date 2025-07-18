using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomStepperSettings : MonoBehaviour
{
    
    public CustomStepper ItemNameSelector;

  
    public List<string> _names = new List<string>()
   {
        "Easy",
        "Normal",
        "Hard"
    };

    
   
    private int _curNameIndex = 0;

    void Start()
    {
        
        ItemNameSelector.LeftButton.onClick.AddListener(OnNamePrevClick);
		ItemNameSelector.RightButton.onClick.AddListener(OnNameNextClick);
        SetupNameSelector();

    }


    void OnNameNextClick()
    {

        _curNameIndex = (_curNameIndex + 1) % _names.Count;
        SetupNameSelector();

    }

    void OnNamePrevClick()
    {
        _curNameIndex = (_curNameIndex - 1 + _names.Count) % _names.Count;
        SetupNameSelector();

    }

    void SetupNameSelector()
    {
        string currentName = _names[_curNameIndex];
        _curNameIndex = _names.IndexOf(currentName);
        ItemNameSelector.SetItemName(currentName.ToString());

    }

}
