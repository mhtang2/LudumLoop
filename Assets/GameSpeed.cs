using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    float gameSpeed;

    // Start is called before the first frame update
    void Start()
    {
        gameSpeed = 1;
        Time.timeScale = gameSpeed;
    }

    public void Increase()
    {
        Debug.Log("Test");
        gameSpeed *= 2;
        SetGameSpeed();
    }

    public void Decrease()
    {
        gameSpeed /= 2;
        SetGameSpeed();
    }

    private void SetGameSpeed()
    {
        gameSpeed = Mathf.Clamp(gameSpeed, 0.5f, 8f);
        Time.timeScale = gameSpeed;
    }
}
