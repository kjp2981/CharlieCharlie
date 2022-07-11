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
    //�� �Լ��� �����ϸ� transition�� ����ų ������ �ƴ����� �����ؼ� bool�� ��ȯ
}
