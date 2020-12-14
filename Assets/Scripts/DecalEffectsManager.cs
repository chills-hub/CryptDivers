﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalEffectsManager : MonoBehaviour
{
    public GameObject ImpactEffectConcrete;
    public GameObject BulletHoleEffectConcrete;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDecalByType(string tag, RaycastHit bulletHit) 
    {
        if (tag == "Enemy")
        {
            //blood decals
        }
        else 
        {
            var bulletHole = Instantiate(BulletHoleEffectConcrete, bulletHit.point, Quaternion.LookRotation(bulletHit.normal));
            bulletHole.transform.parent = bulletHit.transform;
            Instantiate(ImpactEffectConcrete, bulletHit.point, Quaternion.LookRotation(bulletHit.normal));
        }
    }
}
