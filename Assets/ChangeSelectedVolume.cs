using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSelectedVolume : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioManager AudioManager;

    public enum SelectedAudioEnum
    {
        Player = 1,
        Weapon = 2,
        Enemy = 3,
        Music = 4
    }
    public SelectedAudioEnum SelectedAudio;

    void Start()
    {
        AudioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateVolume() 
    {
        if (SelectedAudio == SelectedAudioEnum.Weapon) 
        {
            foreach (AudioSource source in AudioManager.WeaponSounds) 
            {
                source.volume = this.GetComponent<Slider>().value;
            }
        }
        if (SelectedAudio == SelectedAudioEnum.Player)
        {
            foreach (AudioSource source in AudioManager.PlayerSounds)
            {
                source.volume = this.GetComponent<Slider>().value;
            }
        }

        //Adding Music/Enemy sounds here also
    }
}
