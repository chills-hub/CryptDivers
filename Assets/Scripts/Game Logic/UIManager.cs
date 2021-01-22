using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI AmmoCounter;
    private PlayerController Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmmoCounter();
    }

    void UpdateAmmoCounter() 
    {
        if (Player.CurrentEquippedWeapon == "FireAxe")
        {
            AmmoCounter.text = "";
        }
        else 
        {
            AmmoCounter.text = FindObjectOfType<PlayerController>().CurrentEquippedWeaponAmmo.ToString();
        }
    }
}
