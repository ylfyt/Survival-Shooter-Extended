using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponOrb : MonoBehaviour
{
    public int val = 1;
    public string type = "Direction";
    public GameObject[] Upgrades;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.GetType().Name != "SphereCollider"
)
        {
            getUpgrade(other);
        }

    }

    void getUpgrade(Collider player)
    {
        var playerShooting = player.GetComponentInChildren<PlayerShooting>();


        if (playerShooting == null)
        {
            Debug.Log("Gagal");
        }
        else
        {
            Debug.Log(playerShooting.timeBetweenBullets);
            switch (type)
            {
                case "Faster":
                    playerShooting.timeBetweenBullets -= 0.007f;
                    break;
                default:
                    if (playerShooting.gunDirectionLevel == 3)
                    {
                        break;
                    }
                    playerShooting.gunDirectionLevel += 1;
                    break;
            }

            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
