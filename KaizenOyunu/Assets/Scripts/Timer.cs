using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timer;
    private float seconds;
    private int minutes;
    public Text time_T;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        time_T.text = minutes + ":" + seconds;
    }

    // Update is called once per frame
    void Update()
    {
        timer += UnityEngine.Time.deltaTime;
        time_T.text = "" + timer;

    }
}
