using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollAction : AIAction
{
    [SerializeField]
    private bool isLeft = false;

    private RaycastHit2D ray;

    [SerializeField]
    private float moveTime = 3f;
    [SerializeField]
    private float patrollTime = 5f;
    private float initMoveTime;

    protected override void Awake()
    {
        base.Awake();
        initMoveTime = moveTime;
    }

    public override void TakeAction()
    {
        // 주위 돌아다니는 행동
        if (isLeft == true)
        {
            _enemyBrain.Move(Vector2.left, transform.position);
        }
        else
        {
            _enemyBrain.Move(Vector2.right, transform.position);
        }
        moveTime -= Time.deltaTime;
        patrollTime -= Time.deltaTime;
        if (moveTime < 0)
        {
            moveTime = initMoveTime;
            isLeft = !isLeft;
        }
        if(patrollTime < 0)
        {
            patrollTime = 0;
        }
    }
}
