using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
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

    IEnumerator PlayAudio(AudioSource soundEffect)
    {
        soundEffect.PlayOneShot(soundEffect.clip, 0.7f);
        yield return new WaitForSeconds(1f);
    }
}
