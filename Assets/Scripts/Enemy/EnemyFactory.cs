
using UnityEngine;

public class EnemyFactory : MonoBehaviour, IFactory
{

    [SerializeField]
    public GameObject[] enemyPrefab;
    public Transform[] enemyPositions;

    private bool isBossSummoned = false;

    public GameObject FactoryMethod(int tag)
    {
        if (PlayerInfo.isZenMode)
        {
            tag = Random.Range(0, 6);
        } else {
            if (EnemyManager.waveLevel % 3 == 0) {
                if (!isBossSummoned) {
                    tag = 5;
                    isBossSummoned = true;
                } else {
                    tag = Random.Range(0, 5);
                }
            } else {
                isBossSummoned = false;
                tag = Random.Range(0, 5);
            }
        }

        if (EnemyManager.remainingWeight < 6 && EnemyManager.remainingWeight > 0)
        {
            if (EnemyManager.remainingWeight % 2 == 0)
            {
                tag = 0;
            } else {
                tag = 2;
            }
        }


        EnemyManager.remainingWeight -= MONSTER_WEIGHT.GetWeightByTag(tag);

        int pos;
        if (tag == 1)
        {
            pos = Random.Range(2, 5);
        }
        else
        {
            pos = Random.Range(0, 5);
        }
        GameObject enemy = Instantiate(enemyPrefab[tag], enemyPositions[pos].position, enemyPositions[pos].rotation);
        return enemy;
    }
}