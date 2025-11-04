using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    private float x;
    private float y;
    private float z;

    public float amp;
    private float freq;

    public float idleFreq;
    public float sprintFreq;
    public float walkFreq;

    void Start()
    {
        // Now it's safe to access cameraPosition
        
    }

    public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        idle,
        air
    }


    private void StateHandler()
    {
        // Mode - Crouching
        if (Input.GetKey(crouchKey))
        {
            amp = amp / 2;
            state = MovementState.crouching;
        }

        // Mode - Sprinting
        else if (grounded && Input.GetKey(sprintKey))
        {
            amp = amp;
            freq = sprintFreq;
            state = MovementState.sprinting;

        }

        // Mode - Walking
        else if (grounded)
        {
            freq = walkFreq;
            amp = amp;
            state = MovementState.walking;

        }

        // Mode - Air
        else if (!grounded)
        {
            amp = 0;
            state = MovementState.air;
        }
        else
        {
            amp = amp;
            freq = idleFreq;
            state = MovementState.idle;
        }
    }
    private void Update()
    {
        
        x = cameraPosition.position.x;
        y = cameraPosition.position.y;
        z = cameraPosition.position.z;
        StateHandler();

        transform.position = new Vector3(x, (float)(y + Math.Sin(Time.time * speed)*amp), z);
    }
}
