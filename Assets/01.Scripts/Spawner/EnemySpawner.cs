using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    public UnityEvent EnemySpawnEvent;

    public bool CanSpawn = false;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("¿¡³×¹Ì½ºÆ÷³Ê°¡µÎ°³ÀÎµ¥¿ë°í´Ù¹ÎÀÇ»ï°¢±è¹ä³È³È");
        }
        Instance = this;

    }

    [SerializeField]
    private Vector3 enemiesTrm;

    public Enemy CurEnemy;

    private void Start()
    {
        EnemySpawnEvent?.Invoke();
    }

    public void EnemySpawn()
    {
        CurEnemy = PoolManager.Instance.Pop("Enemy") as Enemy;
        CurEnemy.transform.position = enemiesTrm;
    }

    public void EnemyKill()
    {
        Debug.Log("Kill");
        PoolManager.Instance.Push(CurEnemy);
        EnemySpawnEvent?.Invoke();
    }
}
