using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using vnc;

public class BouncePad : MonoBehaviour
{
    public float force;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RetroController body = other.gameObject.GetComponent<RetroController>();
            body.Velocity = body.Velocity + (Vector3.up * force);
        }
    }
}
