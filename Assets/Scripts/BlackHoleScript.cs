using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleScript : MonoBehaviour
{
    public GameObject MainSprite;
    public int mass;
    private SpriteRenderer spriteRender;
    private int massLower = 0, massHigher = 200;
    private float hueLower = 0.666666f, hueHigher = 0.833333f;
    private float lightLower = 0.2f, lightHigher = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRender = MainSprite.GetComponent<SpriteRenderer>();
        UpdateColor();
    }
    void OnMouseOver()
    {
        if (MainGameScript.Instance.IsStartSpawn())
        {
            return;
        }

        if (Input.GetMouseButtonDown(1)) {
            if (mass < massHigher)
            {
                mass += 10;
                UpdateColor();
            }
        }
        if (Input.GetMouseButtonDown(0)) {
            if (mass > massLower)
            {
                mass -= 10;
                UpdateColor();
            }
        }
    }

    private void UpdateColor()
    {
        float percentage = ((float)mass - massLower) / (massHigher - massLower);
        float hue = hueHigher - percentage * (hueHigher-hueLower);
        hue %= 1;
        hue = hue < 0 ? hue + 1 : hue;
        spriteRender.color = Color.HSVToRGB(hue, 1.0f, lightHigher-percentage*(lightHigher-lightLower));
        Debug.Log(percentage+" "+mass+" " +hue);
    }
}
