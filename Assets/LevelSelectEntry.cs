using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectEntry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string level = transform.Find("Text").GetComponent<Text>().text;
        int stars = PlayerPrefs.GetInt("Level" + level + "Stars");
        for (int i = 1; i < stars + 1; i++)
        {
            transform.Find("Star" + i).GetComponent<Image>().color = new Color32(255, 252, 107, 255);
        }
    }
}
