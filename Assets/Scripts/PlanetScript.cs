using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    public GameObject MainSprite;
    public int mass;
    private SpriteRenderer spriteRender;
    private int massLower = 0, massHigher = 200;
    private float hueHigher = 0.1666f, hueLower = -0.33333f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRender = MainSprite.GetComponent<SpriteRenderer>();
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1)) {
            // Whatever you want it to do.
            mass += 10;
            UpdateColor();
        }
        if (Input.GetMouseButtonDown(0)) {
            // Whatever you want it to do.
            mass -= 10;
            UpdateColor();
        }
    }

    private void UpdateColor()
    {
        float percentage = ((float)mass - massLower) / (massHigher - massLower);
        float hue = percentage * (hueHigher-hueLower) + hueLower;
        hue = hue % 1;
        hue = hue < 0 ? hue + 1 : hue;
        spriteRender.color = Color.HSVToRGB(hue, 0.5f, 0.75f);
        Debug.Log(percentage+" "+mass);
    }
}
