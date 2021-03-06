using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{
    [SerializeField]
    private float health;

    public TestEnemy() 
    {
        EnemyHealth = 50;
    }

    private void Update()
    {
        health = EnemyHealth;

        if (health <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
