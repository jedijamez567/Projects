using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    Vector3 targetAngle = new Vector3(0f, 180f, 0f);
    private Vector3 currentAngle;
    private float lerpTime = 5f;
    float currentLerpTime = 0f;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        currentAngle = transform.eulerAngles;
    }
	
	// FixedUpdate is called once per frame, used for online multiplayer
	void FixedUpdate () {
        ProcessInput();
        RotateRocket();
        currentLerpTime += Time.deltaTime;
	}

    private void RotateRocket()
    {
        currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngle.x, currentLerpTime / lerpTime),
            Mathf.LerpAngle(currentAngle.y, targetAngle.y, currentLerpTime / lerpTime),
            Mathf.LerpAngle(currentAngle.z, targetAngle.z, currentLerpTime / lerpTime));

        transform.eulerAngles = currentAngle;
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.AddRelativeForce(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidBody.AddRelativeForce(Vector3.left);
        }
    }
}
