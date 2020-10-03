using System.Collections;
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
        tick += Time.deltaTime;
        if (tick > delay)
        {
            tick = 0;
            Instantiate(planetToSpawn, transform).transform.localPosition = new Vector3(0, 0, 0);
            amountThrown++;
            if (amountThrown >= amount)
            {
                enabled = false;
            }
        }
    }
}
