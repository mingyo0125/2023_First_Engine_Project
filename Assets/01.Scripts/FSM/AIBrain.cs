using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBrain : MonoBehaviour
{
    [SerializeField]
    private AIState _aiState;

    public void ChangeState(AIState nextstate)
    {
        _aiState = nextstate; //상태전환
    }

    private void Update()
    {
        _aiState?.UpdateState();
    }
}
