using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ResultUI : MonoBehaviour
{
    TextMeshProUGUI name1st;
    TextMeshProUGUI score1st;

    TextMeshProUGUI name2nd;
    TextMeshProUGUI score2nd;

    TextMeshProUGUI name3th;
    TextMeshProUGUI score3th;

    TextMeshProUGUI name4th;
    TextMeshProUGUI score4th;

    [SerializeField] SaveScoreSO scoreSO;

    float[] score = new float[4]; 

    private void Start()
    {
        scoreSort();
        Array.Sort(score, new MaxToMinComparer());
        foreach (int number in score)
        {
            Debug.Log(number);
        }
    }

    public void scoreSort()
    {
        score[0] = scoreSO.player1Score;
        score[1] = scoreSO.player2Score;
        score[2] = scoreSO.player3Score;
        score[3] = scoreSO.player4Score;
    }

    private class MaxToMinComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            // Reverse the comparison for descending order
            return Comparer.Default.Compare(y, x);
        }
    }
}


