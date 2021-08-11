using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Time : MonoBehaviour
{
    private float timer;
    private float seconds;
    private int minutes;
    public Text time_T;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        seconds = 0;
        minutes = 0;        
        time_T.text = minutes + ":" + seconds;
    }

    // Update is called once per frame
    void Update()
    {
        timer += UnityEngine.Time.deltaTime;

        float minutes = Mathf.Floor(timer / 60);
        float seconds = timer % 60;

        time_T.text =  minutes.ToString("00") + ":" + Mathf.RoundToInt(seconds).ToString("00");

    }
}
