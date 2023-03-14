using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text CountTimeText;
    
    public float countTime;
    public bool isPicture;

    public static TimeManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        countTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        CountManager();
    }

    void CountManager()
    {
        if (isPicture)
        {
            CountTimeText.text = String.Format("{0:00}", countTime);
            countTime += Time.deltaTime;
        }
        else
        {
            countTime = 0f;
        }
    }

    public void ChangePictureBool()
    {
        isPicture = false;
        Debug.Log(isPicture);
    }
}