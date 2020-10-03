using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonScript : MonoBehaviour
{
    // Buttons poggers
    public void startButton()
    {
        SceneManager.LoadScene("Matty");
        
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene("Options");

    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");

    }

    public void RestartButton()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(y);

    }

    public void LevelSelectButton()
    {
        SceneManager.LoadScene("LevelSelect");

    }

    public void NextLevelButton()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(y + 1);

    }
}
