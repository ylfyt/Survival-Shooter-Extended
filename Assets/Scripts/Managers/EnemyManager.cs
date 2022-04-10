using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float spawnTime = 3f;

    public GameObject Diagonal;
    public GameObject Speed;
    public WeaponManager weaponManager;

    public int totalWeight;
    public static int remainingEnemies = 0;
    public static int remainingWeight;
    public static int waveLevel;
    int finalLevel = 12;
    public bool isZenMode = true;
    public int weightPerLevel = 10;

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }
    void Start()
    {
        isZenMode = PlayerInfo.isZenMode;

        if (isZenMode)
        {
            InvokeRepeating("Spawn", spawnTime, spawnTime);
            InvokeRepeating("Spawn", spawnTime, spawnTime);

        }
        else
        {
            waveLevel = 1;
            SpawnWave();
            waveLevel++;
        }

    }



    void Update()
    {
        if (playerHealth.isDead) { return; }

        if (!isZenMode)
        {
            if (IsWinning())
            {
                waveLevel--;
                GameOverManager.isWinning = true;
            }
            else
            {
                if (remainingEnemies <= 0)
                {
                    weaponManager.SpawnWeaponUpForWaveMode();
                    SpawnWave();
                    waveLevel++;
                }
            }
        }
    }


    void Spawn()
    {
        if (playerHealth.isDead)
        {
            return;
        }
        int spawnEnemy = Random.Range(0, 5);
        Factory.FactoryMethod(spawnEnemy);

    }

    void SpawnWave()
    {
        totalWeight = weightPerLevel * waveLevel;

        remainingWeight = totalWeight;
        while (totalWeight > 0)
        {
            if (remainingWeight > 0)
            {
                Spawn();
                remainingEnemies++;
            }
            totalWeight -= totalWeight - remainingWeight;
        }
    }

    bool IsWinning()
    {
        return (waveLevel - 1 > finalLevel);
    }
}
