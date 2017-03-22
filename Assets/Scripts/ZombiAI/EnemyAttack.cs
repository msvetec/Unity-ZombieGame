using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float timebetweenAttacks = 0.5f;
    public int attackDamage = 10;
    public int damage = 10;

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
            anim.SetBool("isAttacking", false);
            anim.SetBool("isWalking", true);  
        }

    }
    private void Update()
    {
        timer +=Time.deltaTime;
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

            anim.SetBool("isAttacking", true);
            anim.SetBool("isWalking", false);
            
            playerHealth.TakeDemage(attackDamage);
        }
        

    }

    
}
