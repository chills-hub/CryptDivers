using System;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    private PickupManager PickupManager;
    public int AmmoToAdd;
    public GameEvent PickedUpAmmo;

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
        PickupManager = gameObject.AddComponent<PickupManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickupManager.ApplyAmmoPickup(Convert.ToInt32(WeaponType), AmmoToAdd, transform, PickedUpAmmo);
        }
    }
}
