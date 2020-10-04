using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject planetToSpawn;
    public float delay;
    public int amount;
    public Vector2 thrownVelocity;

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
    }

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
                newPlayer.GetComponent<PlanetScript>().vi = thrownVelocity;
                amountThrown++;
                if (amountThrown >= amount)
                {
                    enabled = false;
                }
            }
        }
    }

    public void ResetStartSpawn()
    {
        tick = 0;
        amountThrown = 0;
    }
}
