using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponOrb : MonoBehaviour
{
    public Transform playershooting;
    public int val = 1;
    public string type = "";

    void OnTriggerEnter (Collider other){
        if(other.tag == "Player" && other.GetType().Name != "SphereCollider"
)
        {
            getUpgrade(other);
        }

    }

    void getUpgrade(Collider player)
    {
        var playerAttribute = player.GetComponent<PlayerAttribute>();
        if(playerAttribute == null){
            Debug.Log("Gagal");
        }
        else{
            Debug.Log("Success");
            // switch(type) 
            // {
            // case "Speed":
            //     playerAttribute.speed += 1; 
            //     break;
            // default:
            //     playerAttribute.power += 1; 
            //     break;
            // }
            Destroy(gameObject);
        }
    }
}
