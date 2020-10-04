using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilledAnimationScript : MonoBehaviour
{
    private enum State
    {
        START,
        PULSE_UP,
        PULSE_DOWN
    }
    State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.START;
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.Lerp(0, 44f, Time.realtimeSinceStartup);
    }
}
