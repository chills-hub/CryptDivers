using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    [SerializeField]
    protected GameObject thisEnemy;
    private float _enemyDamage;

    private void Awake()
    {
        _enemyDamage = thisEnemy.GetComponent<EnemyCore>().EnemyDamageDealt;
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.tag == "Player") 
        {
            if (thisEnemy != null)
            {
                other.gameObject.GetComponent<PlayerController>().ApplyPlayerDamage(_enemyDamage);
                this.gameObject.SetActive(false);
            }
            else 
            {
                throw new System.Exception("trigger enemy GameObject is null for enemy: " + gameObject.GetComponentInParent<EnemyCore>().gameObject.name);
            }
        }
    }
}
