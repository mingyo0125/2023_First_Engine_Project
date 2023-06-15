using UnityEngine.Events;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    public UnityEvent EnemySpawnEvent;

<<<<<<< HEAD
<<<<<<< HEAD
    private bool canSpawn = true;
    public bool CanSpawn => canSpawn;

    private Enemy currentEnemy;
=======
>>>>>>> parent of 717cd9e (ë°”ê¾¸ê¸°ì „)
=======
>>>>>>> parent of 717cd9e (ë°”ê¾¸ê¸°ì „)

    private void Awake()
    {
        if (Instance != null)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            Debug.LogError("Multiple EnemySpawner instances detected!");
=======
            Debug.LogError("¿¡³×¹Ì½ºÆ÷³Ê°¡µÎ°³ÀÎµ¥¿ë");
>>>>>>> parent of 717cd9e (ë°”ê¾¸ê¸°ì „)
=======
            Debug.LogError("¿¡³×¹Ì½ºÆ÷³Ê°¡µÎ°³ÀÎµ¥¿ë");
>>>>>>> parent of 717cd9e (ë°”ê¾¸ê¸°ì „)
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
<<<<<<< HEAD
>>>>>>> parent of 717cd9e (ë°”ê¾¸ê¸°ì „)
=======
>>>>>>> parent of 717cd9e (ë°”ê¾¸ê¸°ì „)

    public void OnEnemyDieAnimationComplete()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        canSpawn = true;
        if (currentEnemy != null)
        {
            PoolManager.Instance.Push(currentEnemy);
            currentEnemy = null;
        }
=======
        if (enemy != null) { PoolManager.Instance.Push(enemy); }
        
>>>>>>> parent of 717cd9e (ë°”ê¾¸ê¸°ì „)
=======
        if (enemy != null) { PoolManager.Instance.Push(enemy); }
        
>>>>>>> parent of 717cd9e (ë°”ê¾¸ê¸°ì „)
    }
}
