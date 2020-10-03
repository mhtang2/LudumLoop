using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    public int mass;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) {
            // Whatever you want it to do.
            mass += 10;
        }
        if (Input.GetMouseButtonDown(1)) {
            // Whatever you want it to do.
            mass -= 10;
        }
    }
}
