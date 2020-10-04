using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeed : MonoBehaviour
{
    float gameSpeed;
    Text displayText;

    // Start is called before the first frame update
    void Start()
    {
        gameSpeed = 1;
        Time.timeScale = gameSpeed;
        displayText = GetComponent<Text>();
        displayText.text = gameSpeed + "x";
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
        displayText.text = gameSpeed + "x";
        Time.timeScale = gameSpeed;
    }
}
