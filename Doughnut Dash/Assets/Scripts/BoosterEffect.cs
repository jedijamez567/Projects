using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterEffect : MonoBehaviour {

    ParticleSystem particles;

	// Use this for initialization
	void Start () {
        particles = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        PlayEffect();
	}

    private void PlayEffect()
    {
        if (Input.GetMouseButton(button: 0))
        {
            if (!particles.isPlaying)
            {
                particles.Play();
            }
        }
        else
        {
            particles.Stop();
        }
    }
}
