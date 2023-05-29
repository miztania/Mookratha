using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SaveScoreSO saveScore;
    public Timer timer;
    public JarnController jarn1;
    public JarnController jarn2;
    public JarnController jarn3;
    public JarnController jarn4;

    private void Start()
    {
        if(saveScore.round == 1)
        {
            saveScore.player1Score = 0;
            saveScore.player2Score = 0;
            saveScore.player3Score = 0;
            saveScore.player4Score = 0;
        }
    }

    private void Update()
    {
        if(timer.currentTime <= 0)//meaning timeup
        {
            saveScore.player1Score = jarn1.currentPoint;
            saveScore.player2Score = jarn2.currentPoint;
            saveScore.player3Score = jarn3.currentPoint;
            saveScore.player4Score = jarn4.currentPoint;
            
            //timeup ui?
            Invoke("LoadNextScene", 3f);
        }
    }

    public void LoadNextScene()
    {
        saveScore.round++;
        if (saveScore.round <= 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("finish");
        }
        else
        {
            saveScore.round = 1;
            SceneManager.LoadScene("ResultScene");
        }
    }

}
