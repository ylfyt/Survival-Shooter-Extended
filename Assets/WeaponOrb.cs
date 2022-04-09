using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponOrb : MonoBehaviour
{
    public Transform playershooting;
    public int val = 1;
    public string type = "Direction";

    void OnTriggerEnter (Collider other){
        if(other.tag == "Player" && other.GetType().Name != "SphereCollider"
)
        {
            getUpgrade(other);
        }

    }

    void getUpgrade(Collider player)
    {
        var playerShooting = player.GetComponentInChildren<PlayerShooting>();
 
 
        if(playerShooting == null){
            Debug.Log("Gagal");
        }
        else{
            Debug.Log(playerShooting.timeBetweenBullets);
            switch(type) 
            {
            case "Faster":
                playerShooting.timeBetweenBullets -= 0.03f; 
                break;
            default:
                playerShooting.gunDirectionLevel += 1; 
                break;
            }
            Destroy(gameObject);
        }
    }
}
