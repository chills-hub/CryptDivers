using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveCrossbow : Weapon
{
    public Animator CrossbowAnimator;
    public AudioSource FireSound;
    public GameObject Projectile;
    public GameObject ObjectToDisable;
    public Transform ProjOrigin;

    public ExplosiveCrossbow()
    {
        //WeaponDamage not used for this due to non-hitscan, assigned as a guide
        WeaponDamage = 100;
        Range = 100f;
        Falloff = 70f;
        FireRate = 0.8f;
        AmmoType = AmmoType.Bolt;
        AmmoCount = 30;
        CurrentAmmo = 30;
        NextTimeToFire = 0.1f;
        Spread = 0.01f;
        InInventory = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (InputManager.fwd > 0 || InputManager.fwd < 0 || InputManager.strafe > 0 || InputManager.strafe < 0)
        {
            if (InputManager.isGrounded)
            {
                CrossbowAnimator.SetBool("Player_Moving", true);
            }
            else
            {
                CrossbowAnimator.SetBool("Player_Moving", false);
            }
        }
        else
        {
            CrossbowAnimator.SetBool("Player_Moving", false);
        }

        if (InputManager.isFiring && Time.timeScale != 0)
        {
            if (!ObjectToDisable.activeInHierarchy && Time.time >= NextTimeToFire && CurrentAmmo > 0)
            {
                CrossbowAnimator.SetTrigger("TriggerReload");
                return;
            }
            
            if (Time.time >= NextTimeToFire && CurrentAmmo > 0 && ObjectToDisable.activeInHierarchy)
            {
                SetNextFireTime();
                DrainAmmo();
                SetAnimatorValues(true);
                ObjectToDisable.SetActive(false);
                FireProjectileWeapon(ProjOrigin.position, Projectile, WeaponDamage);
                RefManager.AudioManager.PlaySemiAutoGunSound(FireSound);
                CrossbowAnimator.SetTrigger("TriggerReload");
            }
        }
        else
        {
            SetAnimatorValues(false);
        }
    }



    void SetAnimatorValues(bool input)
    {
        CrossbowAnimator.SetBool("Crossbow_Fire", input);
    }
}
