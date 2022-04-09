using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PowerOrb;
    public GameObject SpeedOrb;
    public GameObject HealthOrb;
    public int xPos;
    public int zPos;
    public int orbType;

    void Start()
    {
        StartCoroutine(OrbDrop());
    }

    IEnumerator OrbDrop(){
        while(true){
            xPos = Random.Range(-22, 28);
            zPos = Random.Range(-21, 25);
            orbType = Random.Range(1, 3);
            GameObject hitEffect;
            switch(orbType){
                case 1:
                    hitEffect = Instantiate(PowerOrb, new Vector3(xPos, 0.6f, zPos), Quaternion.identity);
                    Destroy(hitEffect, 12f);
                    break;
                case 2:
                    hitEffect = Instantiate(SpeedOrb, new Vector3(xPos, 0.6f, zPos), Quaternion.identity);
                    Destroy(hitEffect, 12f);               
                    break;
                default:
                    hitEffect = Instantiate(HealthOrb, new Vector3(xPos, 0.6f, zPos), Quaternion.identity);       
                    Destroy(hitEffect, 12f);             
                    break;
            }
            
            yield return new WaitForSeconds(10f);
        }
       
    }
}
