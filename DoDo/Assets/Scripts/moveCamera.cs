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

    public float setAmp;
    private float amp;
    private float freq;
	private float phase;

	public float idleFreq;
    public float sprintFreq;
    public float walkFreq;

	private playerMovement pm;
	public MovementState state;

	void Start()
    {
		// Now it's safe to access cameraPosition
		var player = GameObject.FindWithTag("Player");
		pm = player != null ? player.GetComponent<playerMovement>() : null;
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
        if (Input.GetKey(pm.crouchKey))
        {
            amp = setAmp / 2;
            state = MovementState.crouching;
            ;
        }

        // Mode - Sprinting
        else if (pm.grounded && Input.GetKey(pm.sprintKey))
        {
            amp = setAmp;
            freq = sprintFreq;
            state = MovementState.sprinting;
			
		}

        // Mode - Walking
        else if (pm.grounded && pm.GetV() > 0)
        {
            freq = walkFreq;
            amp = setAmp;
            state = MovementState.walking;
			

		}

        // Mode - Air
        else if (!pm.grounded)
        {
            amp = 0;
            state = MovementState.air;
			
		}
        // Mode - idle
        else 
        {
            amp = setAmp;
            freq = idleFreq;
            state = MovementState.idle;
			
		}
    }


    private void Update()
    {

        //tracks position on wave
		phase += freq * 2f * Mathf.PI * Time.deltaTime;

		StateHandler();
		x = cameraPosition.position.x;
        y = cameraPosition.position.y;
        z = cameraPosition.position.z;
       

        
		transform.position = new Vector3(x, (float)(y + Math.Sin(phase) * amp), z);

	}
}
