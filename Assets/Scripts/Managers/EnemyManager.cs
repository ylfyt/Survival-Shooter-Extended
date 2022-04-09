using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float spawnTime = 3f;

    public int totalWeight;
    public static int remainingEnemies = 0;
    public static int remainingWeight;
    public static int waveLevel = 1;
    public bool isZenMode = true;

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }
    void Start()
    {
        isZenMode = PlayerInfo.isZenMode;

        if (isZenMode)
        {
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }
        else
        {
            SpawnWave();
            waveLevel++;
        }

    }

    void Update()
    {
        if (playerHealth.isDead) { return; }

        if (!isZenMode)
        {
            if (IsWinning()) { 
                waveLevel--;
                GameOverManager.isWinning = true; 
            } else {
                if (remainingEnemies <= 0 )
                {
                    Debug.Log("CURRENT WAVE LEVEL IS : " + waveLevel);
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

        totalWeight = 3 * waveLevel;
        
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

    bool IsWinning() {
        Debug.Log("CURRENT WAVE LEVEL IS : " + waveLevel);
        return (waveLevel-1 > 12);
    }
}
