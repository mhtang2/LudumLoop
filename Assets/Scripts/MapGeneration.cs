using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public GameObject planet;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            float x = Random.Range(-100.0f, 100.0f);
            float y = Random.Range(-100.0f, 100.0f);
            GameObject temp = Instantiate(planet);
            temp.transform.position = new Vector3(x, y);
            temp.GetComponent<PlanetScript>().mass = (int) 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
