using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /// <summary>
    /// The enemy health
    /// </summary>
    public float EnemyHealth { get; set; }

    public void TakeDamage(float inputDamage) 
    {
        EnemyHealth -= inputDamage;
        Debug.Log(EnemyHealth);
    }
}
