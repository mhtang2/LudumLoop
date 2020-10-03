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
    private Vector3 v;
    private Vector2 rocketVelocity;
    private List<PlanetDataEntry> orbitingPlanets = new List<PlanetDataEntry>();
    //Tuple (float score, float degreeStart)
    private GameObject[] planets;

    public int completedOrbits;
    public double test;

    void Start()
    {
        v = vi;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        planets = GameObject.FindGameObjectsWithTag("Planet");
        foreach (GameObject planet in planets)
        {
            orbitingPlanets.Add(new PlanetDataEntry(0.0, transform.position, planet.GetComponent<PlanetScript>()));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rocketVelocity = (transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)).normalized * 20;
        } else {
            rocketVelocity = new Vector2();
        }
    }
    private void FixedUpdate()
    {
        Vector3 a = Vector3.zero;
        foreach (PlanetDataEntry planet in orbitingPlanets)
        {
            Vector3 r = transform.position - planet.TargetPlanet.transform.position;
            a += -G * planet.TargetPlanet.mass / (r.magnitude * r.magnitude) * r.normalized;
        }
        a += (Vector3) rocketVelocity;
        //Debug.Log(r.magnitude);
        v += Time.deltaTime * a;
        transform.position = transform.position + v * Time.deltaTime;
        CalculateScore();
    }

    private void CalculateScore()
    {
        for(int i = 0; i < orbitingPlanets.Count; i++)
        {
            double score = orbitingPlanets[i].Score;


            Vector2 A = transform.position - orbitingPlanets[i].TargetPlanet.transform.position;
            Vector2 B = orbitingPlanets[i].LastPoint - (Vector2) orbitingPlanets[i].TargetPlanet.transform.position;

            double angleChange = Mathf.Acos(Vector2.Dot(A.normalized, B.normalized));


            score += angleChange;
            orbitingPlanets[i].LastPoint = transform.position;
            orbitingPlanets[i].Score = score;
            test = score;
            completedOrbits = Mathf.Max(completedOrbits, (int) (score / (Mathf.PI * 2)));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //orbitingPlanets.Add(collision.gameObject.GetComponent<PlanetScript>());
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //orbitingPlanets.Remove(collision.gameObject.GetComponent<PlanetScript>());
    }

    private double AngleRadians(Vector2 target, Vector2 origin)
    {
        Vector2 vector2 = target - origin;
        Vector2 vector1 = new Vector2(0, 1); // 12 o'clock == 0°, assuming that y goes from bottom to top

        double angleInRadians = Math.Atan2(vector2.y, vector2.x) - Math.Atan2(vector1.y, vector1.x);
        return angleInRadians;
    }
}
