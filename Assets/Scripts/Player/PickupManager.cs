using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public GameObject Handgun;
    public GameObject Smg;
    public GameObject DoubleBarrel;

    private Inventory PlayerInventory; 

    void Start()
    {
        PlayerInventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

    public void ApplyPickup(string pickup) 
    {
        if (pickup == "Handgun_Pickup")
        {
            PlayerInventory.InventorySlots[1].GetComponent<Weapon>().InInventory = true;
            PlayerInventory.selectedWeapon = 1;
            PlayerInventory.SelectWeapon();
        }

        if (pickup == "SMG_Pickup") 
        {
            PlayerInventory.InventorySlots[2].GetComponent<Weapon>().InInventory = true;
            PlayerInventory.selectedWeapon = 2;
            PlayerInventory.SelectWeapon();
        }

        if (pickup == "Shotgun_Pickup")
        {
            PlayerInventory.InventorySlots[3].GetComponent<Weapon>().InInventory = true;
            PlayerInventory.selectedWeapon = 3;
            PlayerInventory.SelectWeapon();
        }
    }
}
