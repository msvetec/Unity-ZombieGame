using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BunnyMove : MonoBehaviour {

    Transform player;
    //PlayerHealth playerHealth;
    BunnyHealth bunnyHealth;

    NavMeshAgent nav;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //playerHealth = player.GetComponents <PlayerHealth>();
        bunnyHealth = GetComponent<BunnyHealth>();
        nav = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        if (!bunnyHealth.isDead)
            nav.SetDestination(player.position);

    }
}
