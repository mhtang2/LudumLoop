using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    public void StartSpawn()
    {
        MainGameScript.Instance.StartSpawn();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
