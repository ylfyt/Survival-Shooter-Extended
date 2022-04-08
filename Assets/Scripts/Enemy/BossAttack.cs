using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public float radius = 5f;
    Transform player;
    Rigidbody rb;

    public float attackRate = 0.1f;

    float timeToAttack = 0f;

    Animator anim;
    EnemyHealth enemyHealth;

    bool attacking = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (player == null)
        {
            Debug.Log("Boss: Player not found");
            return;
        }
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
    }
    void Update()
    {
        if (player == null)
        {
            return;
        }

        if (enemyHealth.currentHealth <= 0)
        {
            return;
        }

        float dist = Vector3.Distance(player.position, transform.position);

        if (dist <= radius)
        {
            rb.transform.LookAt(player);
            if (!attacking)
            {
                attacking = true;
                Attack();
            }
        }
        else
        {
            anim.SetBool("Attack", false);
            attacking = false;
        }
    }

    void Attack()
    {
        anim.SetBool("Attack", true);
    }
}
