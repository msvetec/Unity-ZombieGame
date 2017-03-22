using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private const string weaponLayerMask = "Weapon";
    
    
    private Enemyhealth enemyHealth;
    //reload weapon
    public bool run = true;
    public bool shoot = true;
    //public bool ammoShoot = true;
    public Camera cam;
    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    private GameObject weaponGFX;
    public int damage = 50;
    public float range = 100f;
    public float fireRate = 10f;
    public int ammoMagazine;
    public int ammo;
    public int _ammoMagazine;
    private int MagazineStatus = 0;
    public bool reload = true;
    public ParticleSystem muzzleFlash;
    public GameObject hitEffectPrefab;

    private bool _isPaused;
    
    private void Awake()
    {
        weaponGFX.layer = LayerMask.NameToLayer(weaponLayerMask);
        enemyHealth = GetComponent<Enemyhealth>();
        _ammoMagazine = ammoMagazine;
    }
    private void Update()
    {
        _isPaused = ScoreManager.isPaused;

        #region Reload
        if (Input.GetKey(KeyCode.R) && run)
        {
            if (ammo != 0)
            {
                Reload();
            }
        }

        if (_ammoMagazine == 0)
        {
            shoot = false;
        }
        else
        {
            shoot = true;

        }
        #endregion

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            run = false;

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            run = true;
        }
        #region Pucanje
        

        //normalano pucanje
        if (fireRate <= 0f)
        {
            if (Input.GetButtonDown("Fire1") && shoot && run)
            {
                Shoot();
            }
        }
        //rafal
        else
        {
            if (Input.GetButtonDown("Fire1") && shoot && run)
            {
                InvokeRepeating("Shoot", 0f, 1f / fireRate);

            }
            else if (Input.GetButtonUp("Fire1"))
            {
                CancelInvoke("Shoot");

            }
        }
        #endregion


    }
    private void Shoot()
    {
        if (_ammoMagazine != 0 && _isPaused)
        {

            _ammoMagazine--;
        }
        else
        {

            return;
        }
        muzzleFlash.Play();

        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, range,mask))
        {
            
            Enemyhealth enemyHealth = _hit.collider.GetComponent<Enemyhealth>();
            BunnyHealth bunnyHealth = _hit.collider.GetComponent<BunnyHealth>();
            if (enemyHealth !=null)
            {                
                enemyHealth.TakeDemage(damage);    
            }
            if (bunnyHealth != null)
            {
                bunnyHealth.TakeDemage(damage);
            }

            OnHitEffect(_hit.point, _hit.normal); // ako smo nesta pogodili pokreni animaciju
        }
    }
    private void Reload()
    {

        MagazineStatus = ammoMagazine - _ammoMagazine; //koliko nam fali do full u šenžeru
        int provjera = 0;
        provjera = ammo - MagazineStatus;

        if (provjera > 0)
        {
            ammo -= MagazineStatus;
            _ammoMagazine = ammoMagazine;
        }
        if (provjera < 0)
        {
            _ammoMagazine = _ammoMagazine + ammo;
            ammo = 0;


            if (ammo == 0)
            {
                reload = false;
                return;
            }
        }

    }
    private void OnHitEffect(Vector3 _pos, Vector3 _normal)
    {
        GameObject _hitEffect = (GameObject)Instantiate(hitEffectPrefab, _pos, Quaternion.LookRotation(_normal));
        Destroy(_hitEffect, 2f);
    }
}
