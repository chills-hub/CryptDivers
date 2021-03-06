using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    protected ReferenceManager _refManager;
    protected PlayerController _playerRef;
    protected EnemyCore thisEnemy;
    [HideInInspector]
    public bool InAttackDistance = false;
    [HideInInspector]
    public bool CanAttack;
    private bool GibsSpawnedAlready = false;

    public enum EnemyTypeEnum
    {
        Ram = 1,
        Slab = 2,
        Icon = 3
    }

    /// <summary>
    /// The enemy health
    /// </summary>
    public float EnemyHealth { get; set; }

    /// <summary>
    /// Is the enemy dead
    /// </summary>
    public bool IsDead { get; set; }

    /// <summary>
    /// The enemy time between attacks in seconds
    /// </summary>
    public float AttackDelay { get; set; }

    /// <summary>
    /// The enemy distance from player to attack
    /// </summary>
    public float AttackDistance { get; set; }

    /// <summary>
    /// The amount of damage the enemy deals
    /// </summary>
    public float EnemyDamageDealt { get; set; }

    /// <summary>
    /// The enemy type
    /// </summary>
    public string EnemyType { get; set; }

    /// <summary>
    /// Should the enemy gib on death
    /// </summary>
    public bool ShouldGib { get; set; }


    private void Awake()
    {
        _refManager = FindObjectOfType<ReferenceManager>();
        _playerRef = _refManager.Player;
        thisEnemy = GetComponentInParent<EnemyCore>();
    }

    public void TakeDamage(float inputDamage) 
    {
        EnemyHealth -= inputDamage;
        Debug.Log(EnemyHealth);

        if (EnemyHealth <= 0 && !IsDead)
        {
            IsDead = true;

            if (ShouldGib && !GibsSpawnedAlready)
            {
                Destroy(transform.gameObject);
                ParticleSystem particles = Instantiate(GetComponentInParent<EnemyCore>().GibParticles, transform.position, Quaternion.identity);
                particles.Play();
                GameObject gibbed = Instantiate(GetComponentInParent<EnemyCore>().GibbedEnemy, transform.position, Quaternion.identity);
                gibbed.GetComponent<GibEnemy>().Explode();
                GibsSpawnedAlready = true;
            }
            else
            {
                GetComponentInParent<Animator>().SetBool("HasDied", true);
                GetComponentInParent<BoxCollider>().enabled = false;
            }
        }
    }

    protected void EnemyMove(NavMeshAgent agent, Animator animator) 
    {
        float playerDist = Vector3.Distance(_playerRef.transform.position, agent.transform.position);

        if (IsDead) 
        {
            this.enabled = false;
            agent.isStopped = true;
            animator.SetBool("IsMoving", false);
            agent.velocity = Vector3.zero;
            return; 
        }

        if (playerDist < AttackDistance && !IsDead)
        {
            if (!animator.GetBool("IsAttacking")) 
            {
                InAttackDistance = true;
                agent.velocity = Vector3.zero;
                agent.transform.LookAt(new Vector3(_playerRef.transform.position.x, transform.position.y, _playerRef.transform.position.z));
                animator.SetBool("IsMoving", false);
                agent.isStopped = true;
            }
        }
        else
        {
                InAttackDistance = false;
                agent.isStopped = false;
                agent.destination = _refManager.Player.transform.position;
                agent.updateRotation = true;
                //agent.transform.LookAt(new Vector3(_playerRef.transform.position.x, transform.position.y, _playerRef.transform.position.z));
                animator.SetBool("IsMoving", true);
        }
    }
}
