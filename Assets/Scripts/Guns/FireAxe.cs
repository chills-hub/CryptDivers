using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAxe : Weapon
{
    public Animator FireAxeAnimator;

    public FireAxe()
    {
        WeaponDamage = 40;
        Range = 1f;
        FireRate = 10f;
        NextTimeToFire = 0;
        Spread = 0.01f;
        InInventory = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.fwd > 0 || InputManager.fwd < 0 || InputManager.strafe > 0 || InputManager.strafe < 0)
        {
            if (InputManager.isGrounded)
            {
                FireAxeAnimator.SetBool("Player_Moving", true);
            }
            else
            {
                FireAxeAnimator.SetBool("Player_Moving", false);
            }
        }
        else
        {
            FireAxeAnimator.SetBool("Player_Moving", false);
        }

        if (InputManager.isFiring)
        {
            if (Time.time >= NextTimeToFire)
            {
                //PlayGunSound();
                SetNextFireTime();
                SetAnimatorValues(true);
                SwingMeleeWeapon(PlayerGunCamera.transform.position);
            }
        }
        else
        {
            //StopGunSound();
            SetAnimatorValues(false);
        }
    }

    void SetAnimatorValues(bool input)
    {
        FireAxeAnimator.SetBool("FireAxe_Fire", input);
    }

    void PlayGunSound()
    {
        RefManager.AudioManager.PlaySemiAutoGunSound(GetComponent<AudioSource>());
    }
}
