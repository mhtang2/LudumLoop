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
    private GameObject starContainer;

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
    }

    public void StartSpawn()
    {
        startSpawn = true;
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
        if (totalPlanet <= 0)
        {
            //ADD WHAT HAPPENS WHEN LOSE

        }
    }
    public void IncrementScore(int ds) {
        score += ds;
        scoreText.text = score + "/" + goalScore;
        
        if (score == goalScore)
        {
            GameObject.Find("Canvas").transform.Find("EndGame").gameObject.SetActive(true);
            for (int i = stars; i < 3; i++)
            {
                GameObject.Find("Full Star " + i).SetActive(false);
                Debug.Log("test");
            }
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
