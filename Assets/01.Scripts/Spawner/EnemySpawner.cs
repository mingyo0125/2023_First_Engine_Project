using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Enemy> EnemyList = new List<Enemy>();

    private void Start()
    {
        EnemySpawn();
    }

    public void EnemySpawn()
    {
        for(int i = 0; i < 5; i++)
        {
            Enemy enemy =  PoolManager.Instance.Pop("Enemy") as Enemy;
            EnemyList.Add(enemy);
            enemy.transform.position = new Vector3(0, 0, 3f * i);
        }
    }
}
