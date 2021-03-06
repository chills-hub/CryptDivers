using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public Weapon Handgun;
    public Weapon Smg;
    public Weapon DoubleBarrel;
    public Weapon Crossbow;

    private Inventory PlayerInventory;

    void Start()
    {
        PlayerInventory = GameObject.Find("Player").GetComponent<Inventory>();
        Handgun = PlayerInventory.InventorySlots[1].GetComponent<Weapon>();
        Smg = PlayerInventory.InventorySlots[2].GetComponent<Weapon>();
        DoubleBarrel = PlayerInventory.InventorySlots[3].GetComponent<Weapon>();
        Crossbow = PlayerInventory.InventorySlots[4].GetComponent<Weapon>();
    }

    public void ApplyPickup(int weaponType) 
    {
        //Handgun
        if (weaponType == 1 )
        {
            Handgun.InInventory = true;
            PlayerInventory.selectedWeapon = 1;
            PlayerInventory.SelectWeapon();
        }
        //SMG
        if (weaponType == 2) 
        {
            Smg.InInventory = true;
            PlayerInventory.selectedWeapon = 2;
            PlayerInventory.SelectWeapon();
        }
        //Shotgun
        if (weaponType == 3)
        {
            DoubleBarrel.InInventory = true;
            PlayerInventory.selectedWeapon = 3;
            PlayerInventory.SelectWeapon();
        }
        //Crossbow
        if (weaponType == 4)
        {
            Crossbow.InInventory = true;
            PlayerInventory.selectedWeapon = 4;
            PlayerInventory.SelectWeapon();
        }
    }

    public void ApplyAmmoPickup(int weaponType, int ammoToAdd, Transform transform, GameEvent pickedUpEVent)
    {

        //Handgun
        if (weaponType == 1)
        {
            if (Handgun.CurrentAmmo < Handgun.AmmoCount)
            {
                Handgun.CurrentAmmo += ammoToAdd;
                pickedUpEVent.Raise();
                Destroy(transform.gameObject);

                if (Handgun.CurrentAmmo > Handgun.AmmoCount)
                {
                    Handgun.CurrentAmmo = Handgun.AmmoCount;
                }
            }
            else { return; }
        }
        //SMG
        if (weaponType == 2)
        {
            if (Smg.CurrentAmmo < Smg.AmmoCount)
            {
                Smg.CurrentAmmo += ammoToAdd;
                pickedUpEVent.Raise();
                Destroy(transform.gameObject);

                if (Smg.CurrentAmmo > Smg.AmmoCount)
                {
                    Smg.CurrentAmmo = Smg.AmmoCount;
                }
            }
            else { return; }
        }
        //Shotgun
       if (weaponType == 3)
        {
            if (DoubleBarrel.CurrentAmmo < DoubleBarrel.AmmoCount)
            {
                DoubleBarrel.CurrentAmmo += ammoToAdd;
                pickedUpEVent.Raise();
                Destroy(transform.gameObject);

                if (DoubleBarrel.CurrentAmmo > DoubleBarrel.AmmoCount)
                {
                    DoubleBarrel.CurrentAmmo = DoubleBarrel.AmmoCount;
                }
            }
            else { return; }
        }
        //Crossbow
        if (weaponType == 4)
        {
            if (Crossbow.CurrentAmmo < Crossbow.AmmoCount)
            {
                Crossbow.CurrentAmmo += ammoToAdd;
                pickedUpEVent.Raise();
                Destroy(transform.gameObject);

                if (Crossbow.CurrentAmmo > Crossbow.AmmoCount)
                {
                    Crossbow.CurrentAmmo = Crossbow.AmmoCount;
                }
            }
            else { return; }
        }
    }
}
