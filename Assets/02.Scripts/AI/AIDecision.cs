using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    protected AIActionData _aiActionData;
    protected AIMovementData _aiMovementData;
    protected EnemyAIBrain _enemyBrain;

    protected virtual void Awake()
    {
        _aiActionData = transform.GetComponentInParent<AIActionData>();
        _aiMovementData = transform.GetComponentInParent<AIMovementData>();
        _enemyBrain = transform.GetComponentInParent<EnemyAIBrain>();
    }

    public abstract bool MakeADecision(); 
    //이 함수를 실행하면 transition을 일으킬 것인지 아닌지를 결정해서 bool로 반환
}
