using UnityEngine;
using System.Collections;

public class Handgun : Weapon
{
    public Animator HandgunAnimator;
    public AudioSource FireSound;

    public Handgun()
    {
        WeaponDamage = 6;
        Range = 100f;
        Falloff = 70f;    
        FireRate = 6f;
        AmmoType = AmmoType.Pistol;
        AmmoCount = 200;
        CurrentAmmo = 200;
        NextTimeToFire = 0;
        Spread = 0.01f;
        InInventory = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.fwd > 0 || InputManager.fwd < 0 || InputManager.strafe > 0 || InputManager.strafe < 0)
        {
            if (InputManager.isGrounded)
            {
                HandgunAnimator.SetBool("Player_Moving", true);
            }
            else
            {
                HandgunAnimator.SetBool("Player_Moving", false);
            }
        }
        else
        {
            HandgunAnimator.SetBool("Player_Moving", false);
        }

        if (InputManager.isFiring && CurrentAmmo > 0  && Time.timeScale != 0)
        {

            if (Time.time >= NextTimeToFire && CurrentAmmo > 0)
            {
                SetNextFireTime();
                DrainAmmo();
                SetAnimatorValues(true);
                FireHitscanWeapon(PlayerGunCamera.transform.position, 1, Spread);
                RefManager.AudioManager.PlaySemiAutoGunSound(FireSound);
            }
        }
        else
        {
            SetAnimatorValues(false);
        }
    }

    void SetAnimatorValues(bool input)
    {
        HandgunAnimator.SetBool("Handgun_Fire", input);
    }
}
