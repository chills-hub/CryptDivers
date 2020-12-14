using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int selectedWeapon = 0;
    //maybe change this to a list of generics containing both the weapon AND the animator controller
    public List<GameObject> InventorySlots;
    public List<RuntimeAnimatorController> Animators;
    private GameObject RightHand;

    // Start is called before the first frame update
    void Start()
    {
        RightHand = GameObject.Find("Right_Hand");
        SelectWeapon();
    }

    public void ScrollWeaponsUp() 
    {
        if (selectedWeapon >= InventorySlots.Count - 1)
        {
            selectedWeapon = 0;
        }
        else selectedWeapon++;

        if (InventorySlots[selectedWeapon].GetComponent<Weapon>().InInventory)
        {
            StartCoroutine(WaitForLowerWeapon());
        }
        else
        {
            if (selectedWeapon >= InventorySlots.Count - 1)
            {
                selectedWeapon = 0;
            }
            else 
            {
                ScrollWeaponsUp();
            }
        }
    }

    public void ScrollWeaponsDown()
    {
        if (selectedWeapon <= 0)
        {
            selectedWeapon = InventorySlots.Count - 1;
        }
        else selectedWeapon--;

        if (InventorySlots[selectedWeapon].GetComponent<Weapon>().InInventory)
        {
            StartCoroutine(WaitForLowerWeapon());
        }
        else
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = InventorySlots.Count - 1;
            }
            else 
            {
                ScrollWeaponsDown();
            }         
        }
    }

    public void SelectWeapon() 
    {
        for (int i = 0; i < InventorySlots.Count; i++) 
        {
            if (InventorySlots.IndexOf(InventorySlots[i]) == selectedWeapon && InventorySlots[i].GetComponent<Weapon>().InInventory)
            {
                InventorySlots[i].SetActive(true);
                InventorySlots[i].GetComponentInParent<Animator>().runtimeAnimatorController = Animators[i];

                if (InventorySlots[i].gameObject.name == "Shotgun")
                {
                    RightHand.SetActive(false);
                }
                else
                {
                    RightHand.SetActive(true);
                }
            }
            else 
            {
                InventorySlots[i].SetActive(false);
            }
        }
    }

    IEnumerator WaitForLowerWeapon() 
    {
            InventorySlots[selectedWeapon].GetComponentInParent<Animator>().SetTrigger("Switch_Weapon");
            yield return new WaitForSeconds(0.4f);
            SelectWeapon();
            InventorySlots[selectedWeapon].GetComponentInParent<Animator>().SetTrigger("Raise_Weapon");
    }
}
