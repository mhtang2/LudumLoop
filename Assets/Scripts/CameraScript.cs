using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float smoothSpeed = 0.001f;

    private GameObject player;
    private Transform target;
    private Vector3 offset;
    public Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        offset = new Vector3(0, 0, -10);

        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, player.transform.position, ref velocity, smoothSpeed);
        transform.position += offset;
    }
}
