using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITransition : MonoBehaviour
{
    public List<AIDecision> decisions; //결정할 것들의 리스트

    public AIState positiveState;
    public AIState negativeState;
}
