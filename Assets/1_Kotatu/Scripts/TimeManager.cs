using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static float CountDownTime;
    public Text TextCountDown;
    
    public float countTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        CountDownTime = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
        TextCountDown.text = String.Format("{0:00}", CountDownTime);
        CountDownTime -= Time.deltaTime;
    }
}