using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    public List<AITransition> Transitions = null;
    public List<AIAction> Actions = null;

    private AIBrain _brain;
    private void Awake()
    {
        Transitions = new List<AITransition>();
        GetComponentsInChildren<AITransition>(Transitions);

        Actions = new List<AIAction>();
        GetComponents<AIAction>(Actions);

        _brain = transform.GetComponentInParent<AIBrain>();
        
    }

    public void UpdateState()
    {

        foreach(AIAction action in Actions)
        {
            action.TakeAction();
        }

        foreach(AITransition transition in Transitions)
        {
            if(transition.CheckTransition())
            {
                //상태 전환
                _brain.ChangeState(transition._NextState);
                break;
            }
        }
    }
}
