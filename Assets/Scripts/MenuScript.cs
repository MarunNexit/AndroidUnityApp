using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuScript : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject EndMenu;
    public GameObject TopMenu;
    public Text scoreLabel;
    public ScoreManager score1;
    public BallCreation ballCreation;
   

    void Start()
    {
        StartMenu.SetActive(true);
        EndMenu.SetActive(false);
    }

    public void StartGame()
    {
        score1.Restart();
        StartMenu.SetActive(false);
        TopMenu.SetActive(true);
        ballCreation.OnPause = false;
    }

    public void RestartGame()
    {
        score1.Restart();
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
        {
            GameObject.Destroy(ball);
        }
        EndMenu.SetActive(false);
        TopMenu.SetActive(true);
        ballCreation.OnPause = false;
    }
    public void EndGame()
    {
        scoreLabel.text = score1.GetScore().ToString();
        EndMenu.SetActive(true);
        TopMenu.SetActive(false);
        ballCreation.OnPause = true;
    }
    public void Exit()
    {
        Application.Quit();
    }


}
