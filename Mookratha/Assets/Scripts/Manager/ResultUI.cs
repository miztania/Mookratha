using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ResultUI : MonoBehaviour
{
    public TextMeshProUGUI name1st;
    public TextMeshProUGUI score1st;

    public TextMeshProUGUI name2nd;
    public TextMeshProUGUI score2nd;

    public TextMeshProUGUI name3th;
    public TextMeshProUGUI score3th;

    public TextMeshProUGUI name4th;
    public TextMeshProUGUI score4th;

    [SerializeField] SaveScoreSO scoreSO;

    float[] score = new float[4];

    //findname
    int[] tempName = new int[4] {1,2,3,4};

    private void Start()
    {

        scoreSort();
        MaxMinSort(score);
        
        score1st.text = score[0].ToString();
        name1st.text = getName(tempName[0]);

        score2nd.text = score[1].ToString();
        name2nd.text = getName(tempName[1]);

        score3th.text = score[2].ToString();
        name3th.text = getName(tempName[2]);

        score4th.text = score[3].ToString();
        name4th.text = getName(tempName[3]);
    }

    public void scoreSort()
    {
        score[0] = scoreSO.player1Score;
        score[1] = scoreSO.player2Score;
        score[2] = scoreSO.player3Score;
        score[3] = scoreSO.player4Score;

    }

    private void MaxMinSort(float[] array)
    {
        int n = array.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] < array[j + 1])
                {
                    float temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;

                    int temp2 = tempName[i];
                    tempName[i] = tempName[i + 1];
                    tempName[i + 1] = temp2;
                }
            }
        }
    }

    public string getName(int currentScore)
    {
        switch (currentScore)
        {
            case 2:
                return "Player 2";
            case 3:
                return "Player 3";
            case 4:
                return "Player 4";
            default:
                return "Player 1";
        }
    }
}