using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainGameScript : MonoBehaviour
{
    // Game Instance Singleton
    public static MainGameScript Instance { get; private set; } = null;
    private int stars = 0;
    private bool startSpawn = false;
    public int totalMass;
    public int totalPlanet;
    public int goalScore;

    private int score=0;
    private Text scoreText;
    private bool gameOver = false;
    private GameObject starContainer;
    private GameObject loseScreen;
    private GameObject restartButton;
    private GameObject startButton;

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }

        Instance = this;
        starContainer = GameObject.Find("StarIndicator");
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = score + "/" + goalScore;

        Transform canvas = GameObject.Find("LevelUICanvas").transform;
        loseScreen = canvas.Find("LoseGame").gameObject;
        restartButton = canvas.Find("GameUI").Find("Restart").gameObject;
        startButton = canvas.Find("GameUI").Find("Play").gameObject;
    }

    public void StartSpawn()
    {
        startSpawn = true;
        restartButton.SetActive(true);
        startButton.SetActive(false);
    }

    public bool IsStartSpawn()
    {
        return startSpawn;
    }

    public void AddStar()
    {
        stars++;
        starContainer.transform.Find("Filled" + (stars - 1)).gameObject.SetActive(true);
    }

    public void KillPlanet()
    {
        totalPlanet--;
        if (totalPlanet <= 0 && gameOver != true)
        {
            loseScreen.SetActive(true);
            gameOver = true;
        }
    }
    public void IncrementScore(int ds) {
        score += ds;
        scoreText.text = score + "/" + goalScore;
        
        if (score == goalScore && gameOver != true)
        {
            GameObject.Find("LevelUICanvas").transform.Find("EndGame").gameObject.SetActive(true);
            for (int i = stars; i < 3; i++)
            {
                GameObject.Find("Full Star " + i).SetActive(false);
                Debug.Log("test");
            }
            gameOver = true;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelButton()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
