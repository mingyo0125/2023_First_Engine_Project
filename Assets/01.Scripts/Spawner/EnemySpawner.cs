using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    public UnityEvent EnemySpawnEvent;

    public bool CanSpawn = false;

    public Enemy CurEnemy;

    [SerializeField]
    EnemyListSO _enemyListSO;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("¿¡³×¹Ì½ºÆ÷³Ê°¡µÎ°³°í´Ù¹ÎÀÇ»ï°¢±è¹ä³È³È");
        }
        Instance = this;
    }

    [SerializeField]
    private Vector3 enemiesTrm;

    private void Start()
    {
        EnemySpawnEvent?.Invoke();
    }

    public void EnemySpawn()
    {
        int rand = Random.Range(0, _enemyListSO.List.Count);

        CurEnemy = PoolManager.Instance.Pop(_enemyListSO.List[rand].prefab.name) as Enemy;
        CurEnemy.transform.position = enemiesTrm;

    }

    public void EnemyKill()
    {
        Debug.Log("Kill");
        PoolManager.Instance.Push(CurEnemy);
        EnemySpawnEvent?.Invoke();
    }
}
