
using UnityEngine;

public class EnemyFactory : MonoBehaviour, IFactory
{

    [SerializeField]
    public GameObject[] enemyPrefab;
    public Transform[] enemyPositions;

    private bool isBossSummoned = false;

    public GameObject FactoryMethod(int tag)
    {
        if (tag == 2 && !isBossSummoned && EnemyManager.waveLevel % 3 == 0)
        {
            isBossSummoned = true;
        } else if (isBossSummoned || EnemyManager.waveLevel % 3 != 0)
        {
            tag = Random.Range(0, 2);
        }

        int pos;
        if (tag == 1)
        {
            pos = Random.Range(2, 5);
        } else {
            pos = Random.Range(0, 5);
        }
        GameObject enemy = Instantiate(enemyPrefab[tag], enemyPositions[pos].position, enemyPositions[tag].rotation);
        return enemy;
    }
}