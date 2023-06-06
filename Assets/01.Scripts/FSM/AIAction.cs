using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIAction : MonoBehaviour
{
    protected AIBrain _brain;

    protected virtual void Awake()
    {
        _brain = transform.GetComponentInParent<AIBrain>();
    }

    public abstract void TakeAction();
}
