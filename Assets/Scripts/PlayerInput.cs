using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerScript))]
public class PlayerInput : MonoBehaviour
{
    //Instance of PlayerScript. Needs to also be attached to player
    private PlayerScript ps;

    // Start is called before the first frame update
    void Start()
    {
        //ps = gameObject.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            ps.FlipIsOrbited();
            Debug.Log(ps.GetIsOrbited());
        }
        */
    }
}
