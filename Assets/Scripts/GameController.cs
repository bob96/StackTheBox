using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour {

    private bool gameOver;
    public static Transform stackHolder;
    public GameObject stackH;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI LevelText;
    public static int score;
    public static int level;
    public static bool nextLevel;
    public GameObject gameOverLayout;
    public GameObject pausePanel;




    private void Start()
    {
        gameOver = false;
        scoreText.text = "0";
        LevelText.text = "1";
        score = 0;
        level = 1;
        stackHolder = stackH.transform;
        UpdateLevel();
        
    }

    private void Update()
    {
        Debug.Log(MoveObject.speed);
        
        if (gameOver)
        {
            
            Invoke("CallPauseGameInGameOver", 0.8f);
            
        }
    }

    void CallPauseGameInGameOver()
    {
        PauseGame(gameOverLayout);
    }

    public void UpdateScore(int scoreValue)
    {
        score += scoreValue;
        scoreText.text = "" + score;
    }

    public void UpdateLevel()
    {
        LevelText.text = "" + level;
    }
    public void AddLevel()
    {
        level++;
    }

    public void GameOver()
    {
        gameOver = true;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        Debug.Log(Time.timeScale);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOver = false;
    }

    public void UnPause()
    {
        ContinueGame(pausePanel);
    }

    public void Pause()
    {
        PauseGame(pausePanel);
    }

    private void PauseGame(GameObject pause)
    {
        Time.timeScale = 0;

        pause.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    }
    private void ContinueGame(GameObject pause)
    {
        Time.timeScale = 1;
        pause.SetActive(false);
        //enable the scripts again
    }

    private int levelToLoad;


    public void FadeToLevel(int levelIndex)
    {
        gameOver = false;
        Time.timeScale = 1;
        levelToLoad = levelIndex;
        SceneManager.LoadScene(levelToLoad);
    }
}
