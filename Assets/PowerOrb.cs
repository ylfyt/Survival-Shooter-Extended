using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOrb : MonoBehaviour
{
    public int val = 1;
    public string type = "Power";

    void OnTriggerEnter (Collider other){
        if(other.tag == "Player" && other.GetType().Name != "SphereCollider"
)
        {
            getEffect(other);
        }

    }

    void getEffect(Collider player)
    {
        var playerAttribute = player.GetComponent<PlayerAttribute>();
        if(playerAttribute == null){
            Debug.Log("Gagal");
        }
        else{
            Debug.Log("Success");
            switch(type) 
            {
            case "Health":
                playerAttribute.health += 10; 
                break;
            case "Speed":
                playerAttribute.speed += 1; 
                break;
            default:
                playerAttribute.power += 1; 
                break;
            }
            Destroy(gameObject);
        }
    }
}
