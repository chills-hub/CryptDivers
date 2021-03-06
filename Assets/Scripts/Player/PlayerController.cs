using System.Collections.Generic;
using UnityEngine;
using vnc;

public class PlayerController : PlayerStats
{
    public Transform playerView; //The transform containing the player view
    public RetroController retroController; //The retro controller to accept input
    public ReferenceManager refManager;
    public float CurrentEquippedWeaponAmmo;
    public string CurrentEquippedWeapon;
    private float nextFootstep = 0;

    [Header("Player Audio")]
    public AudioSource FootStepSource;
    public AudioSource JumpSource;
    public AudioSource AmmoPickup;


    public AudioClip BasicGround;
    public AudioClip Grass;
    public AudioClip Stone;
    public AudioClip Water;
    public AudioClip JumpSound;
    public AudioClip AmmoPickupSound;


    [SerializeField]
    private float footStepDelay;
    [SerializeField]
    private float sprintFootStepDelay;

    [HideInInspector]
    [Header("Animation")]
    public Animator playerAnimator;

    [HideInInspector]
    public float animDelta = 6f;
    float animHorizontal, animVertical;

    void Update()
    {
        HandleSounds();
        SetAnimatorParameters();

        if (!GetComponentInChildren<Weapon>().Equals(null))
        {
            CurrentEquippedWeaponAmmo = GetComponentInChildren<Weapon>().CurrentAmmo;
            CurrentEquippedWeapon = GetComponentInChildren<Weapon>().gameObject.name;
        }
    }

    void CheckSpreadValue()
    {
        //if less than 1 use spread value else round down or minus
    }

    private void SetAnimatorParameters()
    {
        if (playerAnimator)
        {
            float angle = playerView.eulerAngles.x;
            angle = (angle > 180) ? angle - 360 : angle;
            playerAnimator.SetFloat("Angle", angle);

            animHorizontal = Mathf.MoveTowards(animHorizontal, retroController.inputDir.x, Time.deltaTime * animDelta);
            animVertical = Mathf.MoveTowards(animVertical, retroController.inputDir.y, Time.deltaTime * animDelta);

            playerAnimator.SetFloat("Horizontal", animHorizontal);
            playerAnimator.SetFloat("Vertical", FixSmallValues(animVertical));
            playerAnimator.SetFloat("Speed", Mathf.Clamp(retroController.Velocity.magnitude, 1, 3));
            playerAnimator.SetBool("Ducking", retroController.IsDucking);
            playerAnimator.SetBool("OnGround", retroController.IsGrounded);
        }
    }

    const float SMALL = 0.01f;
    float FixSmallValues(float value)
    {
        if (value > -SMALL && value < SMALL)
            return 0;

        return value;
    }


    //should this be in the audio manager for separation of concern
    private void HandleSounds()
    {
        if (retroController.IsGrounded && GetComponentInParent<InputManager>().isMoving)
        {
            FootStepSource.clip = BasicGround;

            nextFootstep -= Time.deltaTime;
            if (nextFootstep <= 0)
            {
                refManager.AudioManager.PlayFootstepSound(FootStepSource);

                if (retroController.Sprint)
                {
                    nextFootstep += sprintFootStepDelay;
                }
                else
                {
                    nextFootstep += footStepDelay;
                }
            }
        }

        if (GetComponentInParent<InputManager>().jump && retroController.IsGrounded) 
        {
            JumpSource.clip = JumpSound;
            refManager.AudioManager.PlayFootstepSound(JumpSource);
        }
    }

    public void ApplyPlayerDamage(float damageValue) 
    {
        CameraShake.Shake(0.3f, 0.1f);
        float armourDamage = Mathf.Min(CurrentArmour, damageValue);
        float healthDamage = Mathf.Min(CurrentHealth, damageValue);
        CurrentArmour -= armourDamage;
        CurrentHealth -= healthDamage;
    }

    public void PlayAmmoPickupSound() 
    {
       AmmoPickup.clip = AmmoPickupSound;
       refManager.AudioManager.PlayAmmoPickupSound(AmmoPickup);
    }
}
