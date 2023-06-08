using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Vector3 enemiesTrm;

    Enemy enemy;

    public void EnemySpawn()
    {
        enemy = PoolManager.Instance.Pop("Enemy") as Enemy;
        enemy.transform.position = enemiesTrm;
    }

    public void EnemyKill()
    {
        if (enemy != null) { PoolManager.Instance.Push(enemy); }
    }
}
