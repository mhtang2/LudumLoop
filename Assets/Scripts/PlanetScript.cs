using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.VFX;

public class PlanetScript : MonoBehaviour
{
    //Member variables
    private bool IsOrbited;
    public int mass;
    public float G;
    public Vector2 v;
    private Vector2 rocketVelocity = Vector2.zero;
    private List<BlackHoleDataEntry> orbitingPlanets = new List<BlackHoleDataEntry>();
    private bool[] hasOrbited;
    //Tuple (float score, float degreeStart)
    private GameObject[] planets;

    public int completedOrbits;
    public double test;
    public SpriteRenderer spriteRender;
    private TrailRenderer trailRender;

    public AudioClip starSFX;
    private AudioSource SFXsource;
    public static float starPitch;
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        planets = GameObject.FindGameObjectsWithTag("Planet");
        foreach (GameObject planet in planets)
        {
            orbitingPlanets.Add(new BlackHoleDataEntry(0.0f, transform.position, planet.GetComponent<BlackHoleScript>()));
        }
        // Spawn the orbit calculator for this player
        hasOrbited = new bool[orbitingPlanets.Count];
        trailRender = GetComponent<TrailRenderer>();
        SFXsource = GetComponent<AudioSource>();
        UpdateColor();
    }

    // Update is called once per frame
    void Update()
    {
        /**if (Input.GetKey(KeyCode.Space))
        {
            rocketVelocity = (transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)).normalized * 20;
        } else {
            rocketVelocity = Vector2.zero;
        }**/
    }
    private void FixedUpdate()
    {
        Vector2 a = Vector3.zero;
        foreach (BlackHoleDataEntry planet in orbitingPlanets)
        {
           Vector2 r = transform.position - planet.TargetPlanet.transform.position;
           a += -G * planet.TargetPlanet.mass / (r.magnitude * r.magnitude) * r.normalized;
        }
        a +=  rocketVelocity;
        v += Time.deltaTime * a;
        transform.position = transform.position + (Vector3)v * Time.deltaTime;
        if (transform.position.magnitude > 30)
            Destroy(gameObject);
        CalculateAngles();
    }

    /**Selects random color **/
    public void UpdateColor() {
        float roundedHue = UnityEngine.Mathf.Floor(UnityEngine.Random.Range(0.0f, 12.0f)) / 12;
        float trueRandomHue = UnityEngine.Random.Range(0.0f, 1.0f);
        spriteRender.color = Color.HSVToRGB(trueRandomHue,1.0f,1.0f);

        Gradient gradient = new Gradient();
        gradient.mode = GradientMode.Blend;
        Color trailStart = Color.HSVToRGB(trueRandomHue, 1.0f, 0.8f);
        Color trailEnd = Color.HSVToRGB((trueRandomHue + 0.1666f) % 1, 1.0f, 0.8f);
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(trailStart, 0.0f), new GradientColorKey(trailEnd, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 0.01f) }
        );
        trailRender.colorGradient = gradient;
    }

    private void CalculateAngles()
    {
        for(int i = 0; i < orbitingPlanets.Count; i++)
        {
            Vector2 A = transform.position - orbitingPlanets[i].TargetPlanet.transform.position;
            Vector2 B = orbitingPlanets[i].LastPoint - (Vector2) orbitingPlanets[i].TargetPlanet.transform.position;
            float angleChange = -Mathf.Asin(Vector3.Cross(A.normalized,B.normalized).z);
               
            if (!hasOrbited[i] && orbitingPlanets[i].CheckAndUpdate(angleChange,transform.position) ) {
                Debug.Log("1 planet orbit");
                hasOrbited[i] = true;
                if (HandleFullOrbit()) 
                     return;
            }
        }
    }

    //Fully orbited all planets?
    private bool HandleFullOrbit() {
        foreach(bool b in  hasOrbited){
            if (!b) return false;
        }
        hasOrbited = new bool[orbitingPlanets.Count];
        foreach (BlackHoleDataEntry planet in orbitingPlanets) {
            planet.Angle = 0;
            planet.LastPoint = transform.position;
            planet.AngleTargetHigh = Mathf.PI * 2;
            planet.AngleTargetLow = Mathf.PI * -2;
        }
        MainGameScript.Instance.IncrementScore(1);
        completedOrbits++;
        return true;
    }

    private void OnDestroy()
    {
        Debug.Log("Died");
        MainGameScript.Instance.KillPlanet();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //orbitingPlanets.Add(collision.gameObject.GetComponent<PlanetScript>());
        if (collision.tag.Equals("Planet"))
        {
            Destroy(gameObject);
        } else if (collision.tag.Equals("Star"))
        {
            SFXsource.pitch = starPitch;
            SFXsource.PlayOneShot(starSFX);
            starPitch *=1.26f;
            MainGameScript.Instance.AddStar();
            collision.enabled = false;
            collision.transform.Find("Death").gameObject.SetActive(true);
        }
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
