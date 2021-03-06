using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Weapon Sounds")]
    public List<AudioSource> WeaponSounds;

    [Header("Player Sounds")]
    public List<AudioSource> PlayerSounds;

    [SerializeField]
    private GameObject BoltPrefabForAudio;

    private void Start()
    {
        WeaponSounds.Add(BoltPrefabForAudio.GetComponentInChildren<AudioSource>());
    }

    public void PlaySemiAutoGunSound(AudioSource source) 
    {
        source.Play();
    }

    public void PlayAutoGunSound(AudioSource source)
    {
        StartCoroutine(PlayAudio(source));
    }

    public void PlayFootstepSound(AudioSource source)
    {
        source.PlayOneShot(source.clip, 0.7f);
    }

    public void PlayJumpSound(AudioSource source)
    {
        source.Play();
    }

    public void PlayAmmoPickupSound(AudioSource source)
    {
        source.Play();
    }

    IEnumerator PlayAudio(AudioSource soundEffect)
    {
        soundEffect.PlayOneShot(soundEffect.clip, 0.7f);
        yield return new WaitForSeconds(1f);
    }
}
