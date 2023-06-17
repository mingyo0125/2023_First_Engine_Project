using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyPoolingPair
{
    public PoolableMono prefab;
    public int poolCount;
}

[CreateAssetMenu(menuName = "SO/Enemy/list")]
public class EnemyListSO : ScriptableObject
{
    public List<PoolingPair> List;
}
