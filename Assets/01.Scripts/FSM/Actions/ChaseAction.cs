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
        //���� ���������� �ٲ۴�, ���� �Ѿư��� �Ѵ�
        //������Ʈ SetDestination ���ִµ� ��ǥ������ AIbrain�� �ִ� PlayerTrm���� �̾Ƽ�
        //�׺� ����ƽ �־ bake
    }
}
