using UnityEngine.Events;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    public UnityEvent EnemySpawnEvent;

<<<<<<< HEAD
    private bool canSpawn = true;
    public bool CanSpawn => canSpawn;

    private Enemy currentEnemy;
=======
>>>>>>> parent of 717cd9e (바꾸기전)

    private void Awake()
    {
        if (Instance != null)
        {
<<<<<<< HEAD
            Debug.LogError("Multiple EnemySpawner instances detected!");
=======
            Debug.LogError("���׹̽����ʰ��ΰ��ε���");
>>>>>>> parent of 717cd9e (바꾸기전)
        }
        Instance = this;
    }

    [SerializeField]
    private Transform enemiesTransform;

    public void SpawnEnemy()
    {
<<<<<<< HEAD
        currentEnemy = PoolManager.Instance.Pop("Enemy") as Enemy;
        currentEnemy.transform.position = enemiesTransform.position;
    }
=======
        enemy = PoolManager.Instance.Pop("Enemy") as Enemy;
        enemy.transform.position = enemiesTrm;
    }    
>>>>>>> parent of 717cd9e (바꾸기전)

    public void OnEnemyDieAnimationComplete()
    {
<<<<<<< HEAD
        canSpawn = true;
        if (currentEnemy != null)
        {
            PoolManager.Instance.Push(currentEnemy);
            currentEnemy = null;
        }
=======
        if (enemy != null) { PoolManager.Instance.Push(enemy); }
        
>>>>>>> parent of 717cd9e (바꾸기전)
    }
}
