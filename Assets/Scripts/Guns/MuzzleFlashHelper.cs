using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlashHelper : MonoBehaviour
{
    public ParticleSystem HandgunMuzzleFlash;
    public ParticleSystem SmgMuzzleFlash;

    public void PlayMuzzleFlashHandgun()
    {
        HandgunMuzzleFlash.Play();
    }

    public void PlayMuzzleFlashSmg()
    {
        SmgMuzzleFlash.Play();
    }
}
