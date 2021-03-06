using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI AmmoCounter;
    public GameObject Crossshair;
    public TextMeshProUGUI HealthCounter;
    public TextMeshProUGUI ArmourCounter;
    public TextMeshProUGUI PausedText;
    public GameObject PauseMenuPanel;
    public GameObject AudioOptionsButton;
    public GameObject WeaponSoundSlider;
    public TextMeshProUGUI WeaponSoundSliderLabel;
    public GameObject PlayerSoundSlider;
    public TextMeshProUGUI PlayerSoundSliderLabel;
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
        UpdateHealthCounter();
        UpdateArmourCounter();
    }

    void UpdateAmmoCounter() 
    {
        if (Player.CurrentEquippedWeapon == "FireAxe")
        {
            AmmoCounter.text = "";
        }
        else 
        {
            AmmoCounter.text = Player.CurrentEquippedWeaponAmmo.ToString();
        }
    }
    void UpdateHealthCounter()
    {
        HealthCounter.text = Player.CurrentHealth.ToString();
    }

    void UpdateArmourCounter()
    {
        ArmourCounter.text = Player.CurrentArmour.ToString();
    }

    public void ShowPauseMenu() 
    {
        PausedText.gameObject.SetActive(true);
        PauseMenuPanel.SetActive(true);
        AudioOptionsButton.SetActive(true);
    }

    public void HidePauseMenu()
    {
        PausedText.gameObject.SetActive(false);
        PauseMenuPanel.SetActive(false);
        AudioOptionsButton.SetActive(false);
        HideSoundMenu();
    }

    public void OpenSoundMenu()
    {
        WeaponSoundSlider.SetActive(true);
        WeaponSoundSliderLabel.gameObject.SetActive(true);
        PlayerSoundSlider.SetActive(true);
        PlayerSoundSliderLabel.gameObject.SetActive(true);
    }

    public void HideSoundMenu()
    {
        WeaponSoundSlider.SetActive(false);
        WeaponSoundSliderLabel.gameObject.SetActive(false);
        PlayerSoundSlider.SetActive(false);
        PlayerSoundSliderLabel.gameObject.SetActive(false);
    }
}
