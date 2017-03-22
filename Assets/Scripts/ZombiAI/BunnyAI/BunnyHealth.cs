using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BunnyHealth : MonoBehaviour {

    public int startingHealth = 400;
    public int currentHealth;
    public int scoreValue = 250;
    public bool oneTimeRun = false;

    [SerializeField]
    private GameControll gameControll;

    private Animator anim;
    private CapsuleCollider capsuleCollider;
    public bool isDead = false;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = startingHealth;
    }


    public void TakeDemage(int amount)
    {
        if (isDead)
            return;

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death();
        }
    }
    private void Death()
    {

        isDead = true;
        capsuleCollider.isTrigger = true;
        anim.SetTrigger("BunnyIsDeath");
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        ScoreManager.bunnyCounter--;
        ScoreManager.score += scoreValue;
        Destroy(gameObject, 2f);
    }

}
