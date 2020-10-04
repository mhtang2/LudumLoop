﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject planetToSpawn;
    public float delay;
    public int amount;

    private float tick;
    private int amountThrown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MainGameScript.Instance.IsStartSpawn())
        {
            tick += Time.deltaTime;
            if (tick > delay)
            {
                tick = 0;
                GameObject newPlayer;
                (newPlayer= Instantiate(planetToSpawn, transform)).transform.localPosition = new Vector3(0, 0, 0);
                newPlayer.GetComponent<PlanetScript>().UpdateColor();
                amountThrown++;
                if (amountThrown >= amount)
                {
                    enabled = false;
                }
            }
        }
    }
}
