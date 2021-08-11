using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameEnter : MonoBehaviour
{
    public GameObject main;
    public GameObject login;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            login.SetActive(false);
            main.SetActive(true);
        }
    }
}
