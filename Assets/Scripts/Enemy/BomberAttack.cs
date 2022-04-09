using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberAttack : MonoBehaviour
{
    Animator anim;
    EnemyHealth enemyHealth;
    PlayerHealth playerHealth;
    public AudioClip deathClip;
    AudioSource enemyAudio;
    bool isDead = false;

    public int boomDamage = 10;

    void Start()
    {
        anim = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
        enemyAudio = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.GetType().Name != "SphereCollider")
        {
            if (!isDead && enemyHealth.currentHealth > 0)
            {
                isDead = true;
                anim.SetTrigger("Attack");
                playerHealth = other.GetComponent<PlayerHealth>();
            }
        }
    }

    public void BoomPlayer()
    {
        if (playerHealth == null)
        {
            return;
        }
        playerHealth.TakeDamage(boomDamage);
    }

    public void KillBomber()
    {
        isDead = true;
        enemyHealth.currentHealth = 0;

        GetComponent<CapsuleCollider>().isTrigger = true;

        enemyAudio.clip = deathClip;
        enemyAudio.Play();
        EnemyManager.remainingEnemies--;
        ScoreManager.waveScore += enemyHealth.scoreValue;

        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        enemyHealth.SetIsSinking();
        Destroy(gameObject, 2f);
    }
}
