using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAIBrain : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementKeyPress;
    public UnityEvent<Vector2> OnPointerPositionChanged;
    public UnityEvent OnFireButtonPress;

    [SerializeField] protected AIState _currentState;

    public Transform target;
    public Transform basePosition = null;

    private AIActionData _aiActionData;
    public AIActionData AIActionData => _aiActionData;

    protected virtual void Awake()
    {
        _aiActionData = transform.Find("AI").GetComponent<AIActionData>();
    }

    public void SetAttackState(bool state)
    {
        _aiActionData.attack = state;
    }

    private void Start()
    {
        target = GameManager.Instance.PlayerTrm;
    }

    public void Attack()
    {
        OnFireButtonPress?.Invoke();
    }

    public void Move(Vector2 moveDirection, Vector2 targetPosition)
    {
        OnMovementKeyPress?.Invoke(moveDirection);
        OnPointerPositionChanged?.Invoke(targetPosition);
    }

    public void ChangeState(AIState state)
    {
        _currentState = state; //»óÅÂ º¯°æ
    }

    protected virtual void Update()
    {
        if(target == null)
        {
            OnMovementKeyPress?.Invoke(Vector2.zero); //Å¸°Ù ¾øÀ¸¸é ¸ØÃç¶ó
        }
        else
        {
            _currentState.UpdateState();
        }
    }
}
