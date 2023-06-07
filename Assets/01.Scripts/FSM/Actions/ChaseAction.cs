using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseAction : AIAction
{
    private MeshRenderer _renderer;
    private NavMeshAgent _navmeshAgent;

    protected override void Awake()
    {
        base.Awake();
        _renderer = _brain.GetComponent<MeshRenderer>();
        _navmeshAgent = _brain.GetComponent<NavMeshAgent>();
    }

    public override void TakeAction()
    {
        _navmeshAgent.SetDestination(_brain.PlayerTrm.position);
        //나를 빨간색으로 바꾼다, 적을 쫓아가게 한다
        //에이전트 SetDestination 해주는데 목표지점을 AIbrain에 있는 PlayerTrm에서 뽑아서
        //네브 스태틱 넣어서 bake
    }
}
