using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour
{
    //Member variables
    private bool IsOrbited;
    private Rigidbody2D PlayerRigidBody;
    public PlanetScript planet;
    public int mass;
    public float vi;
    public float G;
    // Start is called before the first frame update
    float GM;
    private Vector3 v;
    void Start()
    {
        PlayerRigidBody = gameObject.GetComponent<Rigidbody2D>();
        PlayerRigidBody.velocity = new Vector3(0,vi,0);
        v = new Vector3(0, vi,0);
        GM =    G * planet.mass;
        Debug.Log(GM);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 r = planet.transform.position - transform.position;
        Vector3 a = GM * r / (r.magnitude * r.magnitude * r.magnitude);
        transform.position = transform.position + v * Time.deltaTime;
        v += Time.deltaTime * a;

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
