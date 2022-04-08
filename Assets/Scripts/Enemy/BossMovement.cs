using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    Animator anim;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (enemyHealth == null)
        {
            Debug.Log("EnemyHealt is null");
        }
        if (playerHealth == null)
        {
            Debug.Log("PlayerHealth is null");
        }
        if (enemyHealth.currentHealth > 0 && !playerHealth.isDead)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                nav.SetDestination(player.position);
            }

            if (nav.remainingDistance <= nav.stoppingDistance)
            {
                anim.SetBool("Walk", false);
            }
            else
            {
                anim.SetBool("Walk", true);
            }
        }
        else
        {
            nav.enabled = false;
        }
    }
}
