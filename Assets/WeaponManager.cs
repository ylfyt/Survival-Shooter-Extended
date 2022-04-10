using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject weaponUpgradePrefab;

    public float dropRate = 0.04f;
    float timeToDrop = 25f;

    void Start()
    {
    }

    void WeaponUpgrade()
    {
        var instance = Instantiate(weaponUpgradePrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);

        Destroy(instance, 12f);
    }

    public void SpawnWeaponUpForWaveMode()
    {
        WeaponUpgrade();
    }

    void Update()
    {
        if (PlayerInfo.isZenMode)
        {
            if (Time.time >= timeToDrop)
            {
                timeToDrop = timeToDrop + 1 / dropRate;
                WeaponUpgrade();
            }
        }
    }
}
