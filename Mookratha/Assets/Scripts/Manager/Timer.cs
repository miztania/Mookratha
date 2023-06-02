using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    TextMeshProUGUI minuteText;
    TextMeshProUGUI secondText;
    Animator animator;

    [Header("Timer Setting")]
    public float currentTime;
    public bool countDown;

    private void Start()
    {
        animator = GameObject.Find("Clock").GetComponent<Animator>();
        animator.enabled = false;
        minuteText = GameObject.Find("Minute").GetComponent<TextMeshProUGUI>();
        secondText = GameObject.Find("Second").GetComponent<TextMeshProUGUI>();
        currentTime = 180;
    }

    private void Update()
    {
        if (countDown && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            minuteText.text = ((int)currentTime / 60).ToString();
            secondText.text = returnSecond((int)currentTime);
        }
    }
    public void ClockShake()
    {
        animator.enabled = true;
    }

    private string returnSecond(int currentTime)
    {
        string returnString;
        returnString = (currentTime % 60).ToString();
        if (currentTime % 60 < 10) returnString = "0" + returnString;
        return returnString;
    }
}
