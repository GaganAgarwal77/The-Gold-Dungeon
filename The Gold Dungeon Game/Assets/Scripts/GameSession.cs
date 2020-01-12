using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{

    [SerializeField] int numOfPlayerLives = 3;
    [SerializeField] int playerScore = 0;
    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;

    private void Awake()
    {
        int numOfGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = numOfPlayerLives.ToString();
        scoreText.text = playerScore.ToString();
    }

    public void PlayerDeath()
    {
        if (numOfPlayerLives > 1)
        {
            TakeLife();
        }
        else
        {
           ResetGame();
        }
    }
    public void IncreaseScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
    private void TakeLife()
    {
        numOfPlayerLives -= 1;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = numOfPlayerLives.ToString();
    }
     public void ResetGame()
    {
        SceneManager.LoadScene("Restart Game");
        Destroy(gameObject);
    }
    public void Endgame()
    {
        Destroy(gameObject);
    }


}

