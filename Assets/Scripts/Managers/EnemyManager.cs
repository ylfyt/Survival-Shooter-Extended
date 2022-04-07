using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    // public GameObject enemy;
    public float spawnTime = 3f;

    public int totalEnemies;
    public static int remainingEnemies;
    public static int level;
    public bool isZenMode = true;

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }
    void Start()
    {
        if (isZenMode)
        {
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        } else {
            level = 1;
            SpawnWave();
            level++;
        }
        
    }

    void Update() {
        if (playerHealth.currentHealth <= 0f) { return; }

        if (!isZenMode)
        {
            if (remainingEnemies <= 0 )
            {
                SpawnWave();
                level++;
            }
        }
    }


    void Spawn()
    {
        if (playerHealth.isDead)
        {
            return;
        }

        int spawnEnemy = Random.Range(0, 3);
        Factory.FactoryMethod(spawnEnemy);
        Debug.Log("WAVES remaining enemies : " + totalEnemies);

    }

    void SpawnWave()
    {
        
        totalEnemies = 10 * level;
        remainingEnemies = totalEnemies;
        while (totalEnemies > 0)
        {
            Spawn();
            totalEnemies--;
        }
    }
}
