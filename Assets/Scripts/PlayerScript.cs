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
    private float GM;
    private Vector3 v;
    private ArrayList orbitingPlanets = new ArrayList();
    void Start()
    {
        v = vi;
        GM =G * planet.mass;
        Debug.Log(Mathf.Sqrt(GM / transform.position.magnitude));
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a=Vector3.zero;
        foreach (PlanetScript planet in orbitingPlanets) { 
            Vector3 r = transform.position - planet.transform.position;
            a += -G*planet.mass / (r.magnitude*r.magnitude) * r.normalized;
        }
        //Debug.Log(r.magnitude);
        v += Time.deltaTime * a;
        transform.position = transform.position + v * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        orbitingPlanets.Add(collision.gameObject.GetComponent<PlanetScript>());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        orbitingPlanets.Remove(collision.gameObject.GetComponent<PlanetScript>());
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
