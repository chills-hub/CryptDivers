using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GibEnemy : MonoBehaviour
{
    public float MinForce;
    public float MaxForce;
    public float radius;
    public float destroyDelay;
    public Vector3 parent;

    public void Explode() 
    {
        foreach (Transform transform in transform) 
        {
            var rb = transform.GetComponent<Rigidbody>();

            if (rb != null) 
            {
                rb.AddExplosionForce(Random.Range(MinForce, MaxForce), transform.position, radius, 0.1f);
                rb.AddForce(transform.forward, ForceMode.Impulse);
            }

            Destroy(transform.gameObject, destroyDelay);
        }
    }
   
}
