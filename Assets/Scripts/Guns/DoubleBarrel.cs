using UnityEngine;

public class DoubleBarrel : Weapon
{
    public Animator DoubleBarrelAnimator;

    public DoubleBarrel()
    {
        WeaponDamage = 25;
        AmmoCount = 50;
        CurrentAmmo = 50;
        Range = 100f;
        Falloff = 30f;
        FireRate = 0.8f;
        AmmoType = AmmoType.Shotgun;
        NextTimeToFire = 0.5f;
        Spread = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.fwd > 0 || InputManager.fwd < 0 || InputManager.strafe > 0 || InputManager.strafe < 0)
        {
            if (InputManager.isGrounded) 
            {
                DoubleBarrelAnimator.SetBool("Player_Moving", true);
            }
            else
            {
                DoubleBarrelAnimator.SetBool("Player_Moving", false);
            }
        }
        else
        {
            DoubleBarrelAnimator.SetBool("Player_Moving", false);
        }

        if (InputManager.isFiring)
        {
            if (Time.time >= NextTimeToFire)
            {
                //PlayGunSound();
                SetNextFireTime();
                DrainAmmo();
                SetAnimatorValues(true);
                FireHitscanWeapon(PlayerGunCamera.transform.position, 6 , Spread);
                DoubleBarrelAnimator.SetBool("DoubleBarrel_HasFired", true);
            }
        }
        else
        {
            //StopGunSound();
            SetAnimatorValues(false);
        }

    }

    void SetMuzzles(ParticleSystem muzzle, bool state)
    {
        muzzle.gameObject.SetActive(state);
    }

    void SetAnimatorValues(bool input)
    {
        DoubleBarrelAnimator.SetBool("DoubleBarrel_Fire", input);
    }

    void PlayGunSound()
    {
        RefManager.AudioManager.PlaySound(GetComponent<AudioSource>());
    }

    void StopGunSound()
    {
        RefManager.AudioManager.StopSound(GetComponent<AudioSource>());
    }
}
