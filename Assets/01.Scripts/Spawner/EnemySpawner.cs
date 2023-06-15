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
            Debug.LogError("���׹̽����ʰ��ΰ��ε����ٹ��ǻﰢ���ȳ�");
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
