using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public void PlaySound(AudioSource source) 
    {
        StartCoroutine(PlayAudio(source));
    }

    public void StopSound(AudioSource source)
    {
        source.Stop();
    }

    IEnumerator PlayAudio(AudioSource soundEffect)
    {
        soundEffect.PlayOneShot(soundEffect.clip, 1);
        yield break;
    }
}
