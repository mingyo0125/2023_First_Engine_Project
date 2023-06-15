using UnityEngine.Events;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    public UnityEvent EnemySpawnEvent;

    private bool canSpawn = true;
    public bool CanSpawn => canSpawn;

    private Enemy currentEnemy;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple EnemySpawner instances detected!");
        }
        Instance = this;
    }

    [SerializeField]
    private Transform enemiesTransform;

    public void SpawnEnemy()
    {
        currentEnemy = PoolManager.Instance.Pop("Enemy") as Enemy;
        currentEnemy.transform.position = enemiesTransform.position;
    }

    public void OnEnemyDieAnimationComplete()
    {
        canSpawn = true;
        if (currentEnemy != null)
        {
            PoolManager.Instance.Push(currentEnemy);
            currentEnemy = null;
        }
    }
}
