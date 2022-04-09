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
            xPos = Random.Range(-10, -24);
            zPos = Random.Range(-10, -24);
            orbType = Random.Range(1, 3);
            switch(orbType){
                case 1:
                    Instantiate(PowerOrb, new Vector3(xPos, 0.6f, zPos), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(SpeedOrb, new Vector3(xPos, 0.6f, zPos), Quaternion.identity);                    
                    break;
                default:
                    Instantiate(HealthOrb, new Vector3(xPos, 0.6f, zPos), Quaternion.identity);                    
                    break;
            }
            
            yield return new WaitForSeconds(10f);
        }
       
    }
}
