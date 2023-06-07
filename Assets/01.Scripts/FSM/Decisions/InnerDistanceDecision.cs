using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerDistanceDecision : AIDecision
{
    [SerializeField]
    private Transform _playerTrm;

    [SerializeField]
    private float _range;
    [SerializeField]
    private bool _alwaysVisible;
    [SerializeField]
    LayerMask _layerMask;


    public override bool MakeADecision()
    {
        _playerTrm = GameObject.Find("ArrivedPos").transform;

        bool isIn = Vector3.Distance(_playerTrm.position, transform.position) < _range; //��Ÿ��� ���Դ°�?

        if (isIn)
        {
            //���� �������� �̵�
            _actionData.lastSpotPos = _playerTrm.position;
        }
        else
        {
            //�׺�޽÷� ������ �̵�
        }
        return isIn;
    }

    private void OnDrawGizmos()
    {
        if(UnityEditor.Selection.activeObject == gameObject || _alwaysVisible)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _range);
            Gizmos.color = Color.white;
        }
    }


}
