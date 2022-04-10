using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Diagonal;
    public GameObject Faster;

    public float dropRate = 0.1f;
    float timeToDrop = 10;

    void Start()
    {
    }

    void WeaponUpgrade(){
        var diagonalUpgrade = Instantiate(Diagonal, new Vector3(-10, 0.6f, 0), Quaternion.identity);
        var fasterUpgrade = Instantiate(Faster, new Vector3(0, 0.6f, 0), Quaternion.identity);

        Destroy(diagonalUpgrade, 12f);
        Destroy(fasterUpgrade, 12f);

       


    }

    void Update(){
        if(Time.time >= timeToDrop){
            timeToDrop += 1 / dropRate ;
            WeaponUpgrade();
        }
    }
}
