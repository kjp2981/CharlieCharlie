using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    private EnemyAIBrain _enemyBrain = null;
    public List<AIAction> _actions = null;
    public List<AITransition> _transitions = null;

    private void Awake()
    {
        _enemyBrain = GetComponentInParent<EnemyAIBrain>();

        //GetComponents<AIAction>(_actions);
        //GetComponentsInChildren<AITransition>(_transitions);
    }

    //�� �����Ӹ��� ���� ���¸� �����Ұǵ�
    public void UpdateState()
    {
        //�� ���¿��� ������ �׼��� ���� �����ϰ�
        foreach(AIAction action in _actions)
        {
            action.TakeAction(); //�̷��� �ϸ� � �׼��̵� �����ϰ���
        }

        //���� ���¿��� �ٸ� ���·� ���̰� �̷������ϴ��� üũ�ϰ�
        //�׿� ���� ���̸� ����Ű�ų� ���� �ִ´�.
        foreach(AITransition transition in _transitions)
        {
            bool result = false;
            foreach(AIDecision decision in transition.decisions)
            {
                result = decision.MakeADecision();
                if (!result) break;
            }


            if(result) //��� ������ �����Ѱž�
            {
                if(transition.positiveState != null)
                {
                    _enemyBrain.ChangeState(transition.positiveState);
                    return;
                }
            }
            else //������ �ϳ��� ����
            {
                if(transition.negativeState != null)
                {
                    _enemyBrain.ChangeState(transition.negativeState);
                    return;
                }
            }
        }
    }


}
