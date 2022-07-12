using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAction : AIAction
{
    RaycastHit2D upRay; // 위
    RaycastHit2D downRay; // 아래
    RaycastHit2D leftRay; // 왼쪽
    RaycastHit2D rightRay; // 오른쪽

    RaycastHit2D leftUpRay; // 왼쪽 위 대각선
    RaycastHit2D rightUpRay; // 오른쪽 위 대각선
    RaycastHit2D leftDownRay; // 왼쪽 아래 대각선
    RaycastHit2D rightDownRay; // 오른쪽 아래 대각선

    public override void TakeAction()
    {
        _aiActionData.attack = false;

        upRay = Physics2D.Raycast(transform.position, Vector2.up, 1, 1);
        downRay = Physics2D.Raycast(transform.position, Vector2.down, 1, 1);
        leftRay = Physics2D.Raycast(transform.position, Vector2.left, 1, 1);
        rightRay = Physics2D.Raycast(transform.position, Vector2.right, 1, 1);

        leftUpRay = Physics2D.Raycast(transform.position, new Vector2(-1, 1).normalized, 1, 1);
        leftDownRay = Physics2D.Raycast(transform.position, new Vector2(-1, -1).normalized, 1, 1);
        rightUpRay = Physics2D.Raycast(transform.position, new Vector2(1, 1).normalized, 1, 1);
        rightDownRay = Physics2D.Raycast(transform.position, new Vector2(1, -1).normalized, 1, 1);

        Debug.DrawRay(transform.position, Vector2.up * 1);
        Debug.DrawRay(transform.position, Vector2.down * 1);
        Debug.DrawRay(transform.position, Vector2.left * 1);
        Debug.DrawRay(transform.position, Vector2.right * 1);

        Debug.DrawRay(transform.position, new Vector2(-1, 1).normalized * 1);
        Debug.DrawRay(transform.position, new Vector2(-1, -1).normalized * 1);
        Debug.DrawRay(transform.position, new Vector2(1, 1).normalized * 1);
        Debug.DrawRay(transform.position, new Vector2(1, -1).normalized * 1);

        Vector2 direction = _enemyBrain.target.position - transform.position;
        _aiMovementData.direction = direction.normalized;
        _aiMovementData.pointOfInterest = _enemyBrain.target.position;

        _enemyBrain.Move(_aiMovementData.direction, _aiMovementData.pointOfInterest);
    }
}
