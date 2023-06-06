using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITransition : MonoBehaviour
{
    public List<AIDecision> Decisions;
    public AIState _NextState;

    private void Awake()
    {
        Decisions = new List<AIDecision>();
        GetComponents<AIDecision>(Decisions);
    }

    public bool CheckTransition()
    {
        bool result = false;
        foreach(AIDecision decision in Decisions)
        {
            result = decision.MakeADecision();
            if(decision.IsReverse)
            {
                result = !result;
            }
            if(result == false)
            {
                break;
            }
        }
        return result;
    }
}
