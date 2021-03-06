using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCore : Enemy
{
    [SerializeField]
    protected GameObject AttackCollider;
    [SerializeField]
    private float ThisEnemyHealth;
    [SerializeField]
    private float ThisEnemyDamage;
    [SerializeField]
    private bool ShouldThisEnemyGib;
    [SerializeField]
    private float attackDistance;
    [SerializeField]
    private float attackDelay;
    [SerializeField]
    private EnemyTypeEnum ThisEnemyType;

    private Animator EnemyAnimator;
    private NavMeshAgent agent;

    [Header("Optional Gibbing Objects")]
    public GameObject GibbedEnemy;
    public ParticleSystem GibParticles;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponentInParent<NavMeshAgent>();
        EnemyAnimator = this.GetComponentInParent<Animator>();
        InitialiseEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove(agent, EnemyAnimator);

        //if (InAttackDistance && CanAttack)
        if (InAttackDistance)
        {
            EnemyAnimator.SetBool("IsAttacking", true);
          //  StartCoroutine(AttackCooldown());
        }
        else
        {
            EnemyAnimator.SetBool("IsAttacking", false);
        }
    }

    protected void Attack()
    {
        AttackCollider.SetActive(true);
    }

    void InitialiseEnemy()
    {
        EnemyHealth = ThisEnemyHealth;
        EnemyDamageDealt = ThisEnemyDamage;
        EnemyType = ThisEnemyType.ToString();
        ShouldGib = ShouldThisEnemyGib;
        AttackDistance = attackDistance;
        AttackDelay = attackDelay;
        CanAttack = true;
    }

    IEnumerator AttackCooldown()
    {
        //yield return new WaitForSeconds(1f);
        CanAttack = false;
        yield return new WaitForSeconds(AttackDelay);
        CanAttack = true;
    }
}
