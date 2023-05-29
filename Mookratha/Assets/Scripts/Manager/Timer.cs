using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI minuteText;
    public TextMeshProUGUI secondText;

    [Header("Timer Setting")]
    public float currentTime;
    public bool countDown;

    [Header("Timer Setting")]
    public float timerLimit;

    private void Start()
    {
        currentTime = 180;
    }

    private void Update()
    {
        if (countDown && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            minuteText.text = ((int)currentTime / 60).ToString() ;
            secondText.text = returnSecond((int)currentTime) ;
        }    
    }

    private string returnSecond(int currentTime)
    {
        string returnString;
        returnString = (currentTime % 60).ToString();
        if (currentTime % 60 < 10) returnString = "0" + returnString;
        return returnString;
    }
}
