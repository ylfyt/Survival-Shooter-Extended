using System;
using UnityEngine;

public class EnemyFactory : MonoBehaviour, IFactory
{

    [SerializeField]
    public GameObject[] enemyPrefab;
    public Transform[] enemyPositions;

    public GameObject FactoryMethod(int tag)
    {
        GameObject enemy = Instantiate(enemyPrefab[tag], enemyPositions[tag].position, enemyPositions[tag].rotation);
        return enemy;
    }
}