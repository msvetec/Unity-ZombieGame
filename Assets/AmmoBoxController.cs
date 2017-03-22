using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxController : MonoBehaviour {

    [SerializeField]
    private GameObject ammoBox;
    [SerializeField]
    private PlayerShoot playerShoot;
    private GameObject player;
   
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            playerShoot.ammo += 80;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            Destroy(ammoBox, 1f);
        }

    }
}
