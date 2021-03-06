using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalEffectsManager : MonoBehaviour
{
    public GameObject ImpactEffectConcrete;
    public GameObject BulletHoleEffectConcrete;
    public GameObject BloodImpactEffect;
    public List<GameObject> ListOfBloodDecals;

    public void ApplyDecalByType(string tag, RaycastHit bulletHit) 
    {
        //Ignore Raycast layer is fine for most things

        if (tag == "Enemy")
        {
            //blood decals
            //reason why targets are showing no decals but still taking damage
            //change this for blood
            Instantiate(BloodImpactEffect, bulletHit.point, Quaternion.LookRotation(bulletHit.normal));
        }
        else 
        {
            var bulletHole = Instantiate(BulletHoleEffectConcrete, bulletHit.point, Quaternion.LookRotation(bulletHit.normal));
            bulletHole.transform.parent = bulletHit.transform;
            Instantiate(ImpactEffectConcrete, bulletHit.point, Quaternion.LookRotation(bulletHit.normal));
        }
    }

    public GameObject ReturnGibSplatter() 
    {
        return ListOfBloodDecals[Random.Range(0, 6)];
    }
}
