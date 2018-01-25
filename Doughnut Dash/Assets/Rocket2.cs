using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket2 : MonoBehaviour {

    Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    private void ProcessInput()
    {
        // Upwards Thrust (reletave to top of Rocket)
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up);
        }

        // Moves and Rotates Rocket forwards (based on reletave location)
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        // Moves and Rotates Rocket backwards (based on reletave location)
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back);
        }
    }
}
