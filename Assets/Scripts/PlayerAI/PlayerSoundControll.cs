using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSoundControll : MonoBehaviour
{

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip walk;
    [SerializeField]
    private AudioClip jump;
    [SerializeField]
    private AudioClip fire;
    [SerializeField]
    private AudioClip reload;
    [SerializeField]
    private AudioClip pickUp;

    [SerializeField]
    private PlayerShoot playerShoot;



    float nextFireTime = 0f;
    private bool _isPaused;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    private void Update()
    {
        _isPaused = ScoreManager.isPaused;
        if (nextFireTime <= Time.time && _isPaused && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            nextFireTime = Time.time + 0.3f;
            WalkPlay();

        }


        if (Input.GetKeyDown(KeyCode.Space) && _isPaused)
        {
            JumpPlay();

        }
        if (Input.GetKeyDown(KeyCode.R) /*&& playerShoot._ammoMagazine < 30*/ && playerShoot.ammo > 0)
        {
            ReloadPlay();
        }
        if (Input.GetMouseButtonDown(0) && playerShoot.run && _isPaused)
        {
            InvokeRepeating("FirePlay", 0f, 1f / 10);

        }
        else if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke();
        }

    }
    private void WalkPlay()
    {
        audioSource.priority = 128;
        audioSource.PlayOneShot(walk);
    }
    private void FirePlay()
    {
        audioSource.priority = 1;
        if (playerShoot._ammoMagazine != 0)
        {
            audioSource.PlayOneShot(fire);

        }
    }
    private void JumpPlay()
    {
        audioSource.priority = 128;
        audioSource.PlayOneShot(jump);
    }
    private void ReloadPlay()
    {
        audioSource.priority = 1;
        audioSource.PlayOneShot(reload);

    }



}
