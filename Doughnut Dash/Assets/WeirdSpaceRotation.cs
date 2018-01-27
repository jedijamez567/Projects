using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeirdSpaceRotation : MonoBehaviour {

    static GameObject thisObject;
    float rotationSpeed = 50f;

	// Use this for initialization
	void Start () {
        thisObject = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        Rotate();
	}

    private void Rotate()
    {
        thisObject.transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
    }
}
