using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimation : MonoBehaviour
{
    public new Animation animation;
    [SerializeField]
    private AnimationClip fire;
    [SerializeField]
    private AnimationClip reload;
    [SerializeField]
    private Vector3 aimdownSight;
    [SerializeField]
    private Vector3 hipfire;
    private bool shoot = true;
    [SerializeField]
    private PlayerShoot playerShoot;


  
    private void Update()
    {
        
        FireShot();
        if (Input.GetKey(KeyCode.R) && playerShoot.ammo > 0)
        {
            ReloadWeapon();
        }
        Aiming();
        RunAnimation();

    }

    private void FireShot()
    {
        if (Input.GetButtonDown("Fire1") && shoot && playerShoot._ammoMagazine != 0 && ScoreManager.isPaused )
        {
            PlayAnimation(fire.name);
        }
    }
    private void ReloadWeapon()
    {
            PlayAnimation(reload.name);
    }
    private void Aiming()
    {
        if (Input.GetMouseButton(1) && shoot && ScoreManager.isPaused)
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, aimdownSight, 10 * Time.deltaTime);

        }
        if (Input.GetMouseButtonUp(1))
        {
            transform.localPosition = hipfire;

        }
    }
    private void RunAnimation()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.localRotation = Quaternion.Euler(4, -65, 22);
            shoot = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 4);
            shoot = true;
        }

    }
    private void PlayAnimation(string animName)
    {
        animation.CrossFade(animName);
    }
}
