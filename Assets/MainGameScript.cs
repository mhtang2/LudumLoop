using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameScript : MonoBehaviour
{
    // Game Instance Singleton
    public static MainGameScript Instance { get; private set; } = null;
    private bool startSpawn = false;
    public int totalMass;

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }

        Instance = this;
    }

    public void StartSpawn()
    {
        startSpawn = true;
    }

    public bool IsStartSpawn()
    {
        return startSpawn;
    }
}
