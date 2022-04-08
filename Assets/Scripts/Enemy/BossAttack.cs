using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public float radius = 3.5f;
    Transform player;
    Rigidbody rb;
    public int bossDamage = 35;

    Animator anim;
    EnemyHealth enemyHealth;
    BoxCollider slashColl;
    PlayerHealth playerHealth;

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
        slashColl = GetComponent<BoxCollider>();
        playerHealth = player.GetComponent<PlayerHealth>();
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

        if (dist <= radius && !playerHealth.isDead && enemyHealth.currentHealth > 0)
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


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.GetType().Name != "SphereCollider" && enemyHealth.currentHealth > 0)
        {
            var playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(bossDamage);
        }
    }

    public void SlashOn()
    {
        slashColl.enabled = true;
    }

    public void SlashOff()
    {
        slashColl.enabled = false;
    }

    void Attack()
    {
        anim.SetBool("Attack", true);
    }
}
