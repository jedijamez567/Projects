﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public enum PlayerStatus { Alive, Dead };
    public PlayerStatus currentState;
    Rigidbody rigidBody;
    AudioSource thrustSound;
    Camera mainCamera;
    [SerializeField] float rcsRotation = 130f;
    [SerializeField] float mainThrust = 50f;
    public GameObject explosion;
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        thrustSound = GetComponent<AudioSource>();
        mainCamera = GetComponent<Camera>();
        currentState = PlayerStatus.Alive;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Thrust();
        Rotate();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                // do nothing
                break;
            default:
                Instantiate(explosion, collision.transform);
                Destroy(gameObject);
                currentState = PlayerStatus.Dead;
                print("dead");
                break;
        }
    }

    private void Thrust()
    {
        float thrustThisFrame = mainThrust * Time.deltaTime;
        // Upwards Thrust (reletave to top of Rocket)
        if (Input.GetMouseButton(button: 0))
        {
            rigidBody.AddRelativeForce(Vector3.up / thrustThisFrame);

            if (!thrustSound.isPlaying)
            {
                thrustSound.Play();
            }
        }
        else
        {
            thrustSound.Stop();
        }
    }

    private void Rotate()
    {
        float rotationThisFrame = rcsRotation * Time.deltaTime;
        rigidBody.freezeRotation = true; // Take manual control of rotation

        // Moves and Rotates Rocket forwards (based on reletave location)
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        // Moves and Rotates Rocket backwards (based on reletave location)
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationThisFrame);
        }

        rigidBody.freezeRotation = false; // Resume game rotation control
    }

}
