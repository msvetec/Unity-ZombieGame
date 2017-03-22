using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {

    Transform player;
    Enemyhealth enemyHealth;
    NavMeshAgent nav;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyHealth = GetComponent<Enemyhealth>();
        nav = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        if(!enemyHealth.isDead)
        nav.SetDestination(player.position);

    }
}
