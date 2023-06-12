using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    public UnityEvent EnemySpawnEvent;


    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("���׹̽����ʰ��ΰ��ε���");
        }
        Instance = this;
    }

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
