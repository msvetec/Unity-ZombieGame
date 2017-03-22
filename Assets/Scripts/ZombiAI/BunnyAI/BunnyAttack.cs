using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyAttack : MonoBehaviour {

    public float timebetweenAttacks = 0.5f;
    public int attackDamage = 50;
   
    PlayerHealth playerHealth;
    Animator anim;
    GameObject player;
    bool playerInRange;
    float timer;




    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
            



        }

    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timebetweenAttacks && playerInRange)
        {
            Attack();


        }



    }
    private void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0 && playerInRange)
        {
            

            playerHealth.TakeDemage(attackDamage);
        }


    }
}
