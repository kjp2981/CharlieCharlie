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
    private float initMoveTime;

    protected override void Awake()
    {
        base.Awake();
        initMoveTime = moveTime;
    }

    public override void TakeAction()
    {
        // 주위 돌아다니는 행동
        if(isLeft == true)
        {
            ray = Physics2D.Raycast(transform.position, Vector2.left, 1f);
            if (ray.collider == null)
                _enemyBrain.Move(Vector2.left, transform.position);
            else
            {
                isLeft = !isLeft;
                moveTime = initMoveTime;
            }
        }
        else
        {
            ray = Physics2D.Raycast(transform.position, Vector2.right, 1f);
            _enemyBrain.Move(Vector2.right, transform.position);
            if (ray.collider == null)
                _enemyBrain.Move(Vector2.right, transform.position);
            else
            {
                isLeft = !isLeft;
                moveTime = initMoveTime;
            }
        }
        moveTime -= Time.deltaTime;
        if(moveTime < 0)
        {
            moveTime = initMoveTime;
            isLeft = !isLeft;
        }
    }
}
