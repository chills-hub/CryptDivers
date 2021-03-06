using System;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Animator PickupAnimator;
    private PickupManager PickupManager;

    public enum WeaponTypeEnum
    {
        Handgun = 1,
        SMG = 2,
        Shotgun = 3,
        Crossbow = 4
    }
    public WeaponTypeEnum WeaponType;

    // Start is called before the first frame update
    void Start()
    {
        PickupAnimator = GetComponent<Animator>();
        PickupManager = gameObject.AddComponent<PickupManager>();
        PickupAnimator.Play("Pickup_Spin");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            PickupManager.ApplyPickup(Convert.ToInt32(WeaponType));
            Destroy(transform.gameObject);
        }
    }
}
