using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject planetToSpawn;
    public float delay;
    public int amount;
    public Vector2 thrownVelocity;
    public float spreadDegrees;

    private float tick;
    private int amountThrown;
    private ParticleSystem indicator;

    // Start is called before the first frame update
    void Start()
    {
        indicator = transform.Find("Indicator").GetComponent<ParticleSystem>();

        ParticleSystem.VelocityOverLifetimeModule particleVelocity = indicator.velocityOverLifetime;
        particleVelocity.y = thrownVelocity.magnitude / 2;
        Vector2 defaultVector = new Vector2(0, 1);
        float dot = Vector2.Dot(defaultVector, thrownVelocity);
        float det = defaultVector.x * thrownVelocity.y - defaultVector.y * thrownVelocity.x;
        float angle = Mathf.Atan2(det, dot);
        Debug.Log(angle);
        indicator.transform.Rotate(new Vector3(0, 0, 1), Mathf.Rad2Deg * angle);
        tick = delay;
        dtheta = spreadDegrees / (amount-1);
        newVelocity = RotateVec2(thrownVelocity, spreadDegrees / 2);
    }

    private Vector2 newVelocity;
    private float dtheta;
    // Update is called once per frame
    void Update()
    {
        if (MainGameScript.Instance.IsStartSpawn())
        {
            if (indicator.gameObject.activeSelf)
            {
                indicator.gameObject.SetActive(false);
            }

            tick += Time.deltaTime;
            if (tick > delay)
            {
                tick = 0;
                GameObject newPlayer;
                (newPlayer= Instantiate(planetToSpawn, transform)).transform.localPosition = new Vector3(0, 0, 0);
                newPlayer.GetComponent<PlanetScript>().v = newVelocity;
                amountThrown++;
                newVelocity = RotateVec2(newVelocity, -dtheta);
                if (amountThrown >= amount)
                {
                    enabled = false;
                }
            }
        }
    }

    private Vector2 RotateVec2(Vector2 vec, float deg) {
        float cos = Mathf.Cos(Mathf.Deg2Rad * deg);
        float sin = Mathf.Sin(Mathf.Deg2Rad * deg);
        return new Vector2(vec.x*cos-vec.y*sin,vec.x*sin+vec.y*cos);
    }

    public void ResetStartSpawn()
    {
        tick = 0;
        amountThrown = 0;
    }
}
