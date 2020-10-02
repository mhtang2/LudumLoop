using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour
{
    //Member variables
    private bool IsOrbited;
    private Rigidbody2D PlayerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipIsOrbited()
    {
        IsOrbited = !IsOrbited;
    }

    public bool GetIsOrbited()
    {
        return IsOrbited;
    }
}
