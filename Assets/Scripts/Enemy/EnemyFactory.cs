
using UnityEngine;

public class EnemyFactory : MonoBehaviour, IFactory
{

    [SerializeField]
    public GameObject[] enemyPrefab;
    public Transform[] enemyPositions;

    private bool isBossSummoned = false;

    public GameObject FactoryMethod(int tag)
    {
        if (tag == 2)
        {
            if (EnemyManager.waveLevel % 3 == 0)
            {
                if (!isBossSummoned)
                {
                    isBossSummoned = true;
                } else {
                    tag = Random.Range(0, 2);
                }
            } else {
                isBossSummoned = false;
                tag = Random.Range(0, 2);
            }
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