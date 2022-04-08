using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damaged = 10;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.GetType().Name != "SphereCollider")
        {
            var playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth == null)
            {
                Debug.Log("Something wrong!");
                return;
            }

            if (playerHealth.isDead)
                return;

            playerHealth.TakeDamage(damaged);
            Destroy(gameObject);
        }
    }
}
