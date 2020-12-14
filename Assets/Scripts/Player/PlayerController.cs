using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using vnc;
using vnc.Samples;
using UnityEngine.InputSystem;
using System;
using UnityEngine.InputSystem.Composites;

public class PlayerController : MonoBehaviour
{
    public Transform playerView; //The transform containing the player view
    public RetroController retroController; //The retro controller to accept input
    public float CurrentEquippedWeaponAmmo;
    public string CurrentEquippedWeapon;

    [Header("Animation")]
    public Animator playerAnimator;
    public float animDelta = 6f;
    float animHorizontal, animVertical;

    void Update()
    {
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
}
