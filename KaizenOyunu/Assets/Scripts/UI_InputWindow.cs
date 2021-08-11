using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InputWindow : MonoBehaviour
{
    public GameObject activate;
    public GameObject deactivate;
    public Text txt;

    private string input;

    private void Start()
    {
        
    }

    public void ReadStringInputName(string s)
    {
        input = s;
        txt.text = input;
        Debug.Log(txt);

        deactivate.SetActive(false);
        activate.SetActive(true);
    }
}
