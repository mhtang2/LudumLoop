using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonScript : MonoBehaviour
{
    // Buttons poggers
    public void OptionsButton()
    {
        SceneManager.LoadScene("Options");

    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitsButton()
    {
        Application.Quit();
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

    public void LoadLevel(int index)
    {
        PlayerPrefs.SetInt("LevelScrollValue", (int)GameObject.Find("Text").transform.position.x);
        SceneManager.LoadScene(index);
    }
}
