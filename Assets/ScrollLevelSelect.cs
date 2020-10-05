using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollLevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int value = PlayerPrefs.GetInt("LevelScrollValue");
        if (value != 0)
        {
            transform.position = new Vector2(value, transform.position.y);
        }
    }
}
