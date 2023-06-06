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


    public override bool MakeADecision()
    {
        bool isIn = Vector3.Distance(_playerTrm.position, transform.position) < _range; //사거리에 들어왔는가?
        if(isIn)
        {
            _actionData.lastSpotPos = _playerTrm.position;
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
