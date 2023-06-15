using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    public UnityEvent EnemySpawnEvent;

    public bool CanSpawn;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("¿¡³×¹Ì½ºÆ÷³Ê°¡µÎ°³ÀÎµ¥¿ë°í´Ù¹ÎÀÇ»ï°¢±è¹ä³È³È");
        }
        Instance = this;
        CanSpawn = true;
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
        Debug.Log("Kill");
        if (enemy != null)
        {
            PoolManager.Instance.Push(enemy);
        }
    }
}
