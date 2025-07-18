using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomStepper : MonoBehaviour
{
    public Button LeftButton;
	public Button RightButton;
	public TMP_Text ItemName;

    
    public void SetItemName(string name)
    {
        ItemName.text = name;
    }
       
}
