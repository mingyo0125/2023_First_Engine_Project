using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : AIAction
{
    private MeshRenderer _renderer;

    protected override void Awake()
    {
        base.Awake();
        _renderer = _brain.GetComponent<MeshRenderer>();
    }

    public override void TakeAction()
    {
        _renderer.material.color = new Color(0, 0, 1); //Idle 상태에선 파란색
    }
}
