using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberAttack : MonoBehaviour
{
    Animator anim;
    EnemyHealth enemyHealth;
    PlayerHealth playerHealth;

    bool isDead = false;

    public int boomDamage;

    void Start()
    {
        anim = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.GetType().Name != "SphereCollider")
        {
            if (!isDead)
            {
                isDead = true;
                anim.SetTrigger("Attack");
                enemyHealth.EnemyDeath();

                playerHealth = other.GetComponent<PlayerHealth>();
            }
        }
    }

    public void BoomPlayer()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(boomDamage);
        }
    }
}
