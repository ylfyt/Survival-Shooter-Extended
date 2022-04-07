using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float radius = 15f;
    Transform player;
    public Rigidbody rb;

    public float attackRate = 1f;

    float timeToAttack = 0f;

    Animator anim;
    EnemyHealth enemyHealth;
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float projectileSpeed = 10f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (player == null)
        {
            Debug.Log("Skeleton: Player not found");
        }

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

        if (dist < radius)
        {
            rb.transform.LookAt(player);

            if (Time.time >= timeToAttack)
            {
                timeToAttack = timeToAttack + 1 / attackRate;
                Attack();
            }
        }
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
    }

    public void ShootProjectile()
    {
        GameObject projectileInstance = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody proRb = projectileInstance.GetComponent<Rigidbody>();
        proRb.velocity = shootPoint.forward * projectileSpeed;

        Destroy(projectileInstance, 2);
    }
}
