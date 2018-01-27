using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour { 

    public GameObject player;
    public Rocket.PlayerStatus currentState;

    // Use this for initialization
    void Start () {
        SpawnPlayer();
	}

    public void SpawnPlayer()
    {
        Instantiate(player);
    }

    // Update is called once per frame
    void Update () {
        RevivePlayer();
	}

    private void RevivePlayer()
    {
        if(currentState == Rocket.PlayerStatus.Dead)
        {
            SpawnPlayer();
            currentState = Rocket.PlayerStatus.Alive;
        }
    }
}
