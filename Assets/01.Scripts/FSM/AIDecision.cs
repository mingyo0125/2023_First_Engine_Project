using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    public bool IsReverse = false;

    protected AIActionData _actionData;

    protected virtual void Awake()
    {
        _actionData = GetComponentInParent<AIActionData>();
    }

    public abstract bool MakeADecision();
}
