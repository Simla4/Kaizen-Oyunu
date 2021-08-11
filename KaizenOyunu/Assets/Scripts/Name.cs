using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviour
{
    [SerializeField] private Text txt_name1;
    [SerializeField] private Text txt_name2;
    // Start is called before the first frame update
    void Start()
    {
        txt_name2.text = txt_name1.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
