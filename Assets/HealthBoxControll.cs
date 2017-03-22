using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoxControll : MonoBehaviour {

    [SerializeField]
    private GameObject healthBox;
    private GameObject player;
    [SerializeField]
    private PlayerHealth playerHealth;
  
    

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerHealth.currentHealth = 100;
        }

        
        

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            Destroy(healthBox, 1f);
        }
    }
 

}
