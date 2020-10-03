using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerScript : MonoBehaviour
{
    //Member variables
    private bool IsOrbited;
    public PlanetScript planet;
    public int mass;
    public Vector3 vi;
    public float G;
    // Start is called before the first frame update
    float GM;
    private Vector3 v;
    void Start()
    {
        v = vi;
        GM =G * planet.mass;
        Debug.Log(Mathf.Sqrt(GM / transform.position.magnitude));
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 r = transform.position;
        Vector3 a = -GM / (r.magnitude*r.magnitude) * r.normalized;
        //Debug.Log(r.magnitude);
        v += Time.deltaTime * a;
        transform.position = transform.position + v * Time.deltaTime;

    }

    void OnCollision2DEnter(Collision collision)
    {
        //Output the Collider's GameObject's name
        Debug.Log(collision.collider.name);
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
