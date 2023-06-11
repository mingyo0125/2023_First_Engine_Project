using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("스포너가두개인데용");
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

    public IEnumerator EnemyKill()
    {
        //yield return new WaitForSeconds(0.1f);
        if (enemy != null) { Debug.Log("312"); PoolManager.Instance.Push(enemy); }
        yield return new WaitForSeconds(0.1f);
        
    }
}
