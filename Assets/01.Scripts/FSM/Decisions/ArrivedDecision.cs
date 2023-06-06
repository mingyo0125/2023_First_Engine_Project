using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArrivedDecision : AIDecision
{
    private NavMeshAgent _agent;



    protected override void Awake()
    {
        base.Awake();
        _agent = GetComponentInParent<NavMeshAgent>();
    }

    public override bool MakeADecision()
    {
        return Vector3.Distance(_agent.destination, transform.position) < 0.2f;
    }
}
