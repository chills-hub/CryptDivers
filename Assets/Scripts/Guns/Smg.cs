using UnityEngine;

public class Smg : Weapon
{
    public Animator SmgAnimator;
    public AudioSource FireSound;

    public Smg() 
    {
        WeaponDamage = 10;
        AmmoCount = 500;
        CurrentAmmo = 500;
        Range = 100f;
        Falloff = 60f;
        FireRate = 20f;
        AmmoType = AmmoType.SMG;
        NextTimeToFire = 0;
        Spread = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.fwd > 0 || InputManager.fwd < 0 || InputManager.strafe > 0 || InputManager.strafe < 0)
        {
            if (InputManager.isGrounded)
            {
                SmgAnimator.SetBool("Player_Moving", true);
            }
            else
            {
                SmgAnimator.SetBool("Player_Moving", false);
            }
        }
        else 
        {
            SmgAnimator.SetBool("Player_Moving", false);
        }

        if (InputManager.isFiring && CurrentAmmo > 0)
        {
            if (Time.time >= NextTimeToFire)
            {
                PlayGunSound();
                SetNextFireTime();
                DrainAmmo();
                SetAnimatorValues(true);
                FireHitscanWeapon(PlayerGunCamera.transform.position, 1, Spread);
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
        SmgAnimator.SetBool("SMG_Fire", input);
    }

    void PlayGunSound() 
    {
       RefManager.AudioManager.PlayAutoGunSound(FireSound);
    }
}
