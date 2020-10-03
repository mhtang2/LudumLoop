using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    int gameSpeed;

    // Start is called before the first frame update
    void Start()
    {
        gameSpeed = 1;
        Time.timeScale = gameSpeed;
    }

    public void Increase()
    {
        gameSpeed *= 2;
        Time.timeScale = gameSpeed;
    }

    public void Decrease()
    {
        gameSpeed /= 2;
        Time.timeScale = gameSpeed;
    }
}
