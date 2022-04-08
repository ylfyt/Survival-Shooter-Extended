
using UnityEngine;

public class EnemyFactory : MonoBehaviour, IFactory
{

    [SerializeField]
    public GameObject[] enemyPrefab;
    public Transform[] enemyPositions;

    private bool isBossSummoned = false;

    public GameObject FactoryMethod(int tag)
    {
        if (EnemyManager.waveLevel % 3 == 0) {
            if (!isBossSummoned) {
                tag = 5;
                isBossSummoned = true;
                Debug.Log("Tag = 5");
            } else {
                tag = Random.Range(0, 5);
            }
        } else {
            isBossSummoned = false;
            tag = Random.Range(0, 5);
        }

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