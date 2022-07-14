using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAction : AIAction
{
    [SerializeField]
    private LayerMask hitLayer;
    [SerializeField]
    private float rayDistance = 1f;

    RaycastHit2D upRay; // 위
    RaycastHit2D downRay; // 아래
    RaycastHit2D leftRay; // 왼쪽
    RaycastHit2D rightRay; // 오른쪽

    [System.Obsolete]
    RaycastHit2D leftUpRay; // 왼쪽 위 대각선
    [System.Obsolete]
    RaycastHit2D rightUpRay; // 오른쪽 위 대각선
    [System.Obsolete]
    RaycastHit2D leftDownRay; // 왼쪽 아래 대각선
    [System.Obsolete]
    RaycastHit2D rightDownRay; // 오른쪽 아래 대각선

    public override void TakeAction()
    {
        _aiActionData.attack = false;
        //PathFinding.Instance.StartFindPath(transform.position, Define.Player.transform.position);
        //DrawRay();
        Vector2 direction = _enemyBrain.target.position - transform.position;
        _aiMovementData.direction = direction.normalized;
        _aiMovementData.pointOfInterest = _enemyBrain.target.position;

        _enemyBrain.Move(_aiMovementData.direction, _aiMovementData.pointOfInterest);
        //if (IsNoHitRay() == true)
        //{
        //    Vector2 direction = _enemyBrain.target.position - transform.position;
        //    _aiMovementData.direction = direction.normalized;
        //    _aiMovementData.pointOfInterest = _enemyBrain.target.position;

        //    _enemyBrain.Move(_aiMovementData.direction, _aiMovementData.pointOfInterest);
        //}
        //else
        //{
        //    if (upRay.collider != null)
        //    {
        //        if(_enemyBrain.target.position.x < transform.position.x)
        //        {
        //            _enemyBrain.Move(Vector2.left, _enemyBrain.target.position);
        //        }
        //        else
        //        {
        //            _enemyBrain.Move(Vector2.right, _enemyBrain.target.position);
        //        }
        //    }
        //    else if (leftRay.collider != null)
        //    {
        //        if(_enemyBrain.target.position.y < transform.position.y)
        //        {
        //            _enemyBrain.Move(Vector2.down, _enemyBrain.target.position);
        //        }
        //        else
        //        {
        //            _enemyBrain.Move(Vector2.up, _enemyBrain.target.position);
        //        }
        //    }
        //    else if (rightRay.collider != null)
        //    {
        //        if(_enemyBrain.target.position.y < transform.position.y)
        //        {
        //            _enemyBrain.Move(Vector2.down, _enemyBrain.target.position);
        //        }
        //        else
        //        {
        //            _enemyBrain.Move(Vector2.up, _enemyBrain.target.position);
        //        }
        //    }
        //    else if (downRay.collider != null)
        //    {
        //        if (_enemyBrain.target.position.x < transform.position.x)
        //        {
        //            _enemyBrain.Move(Vector2.left, _enemyBrain.target.position);
        //        }
        //        else
        //        {
        //            _enemyBrain.Move(Vector2.right, _enemyBrain.target.position);
        //        }
        //    }

        //float offset = 2f;
        //if(upRay.collider != null)
        //{
        //    _enemyBrain.Move(Vector2.down * offset, transform.position);
        //}
        //else if(downRay.collider != null)
        //{
        //    _enemyBrain.Move(Vector2.up * offset, transform.position);
        //}
        //else if(leftRay.collider != null)
        //{
        //    _enemyBrain.Move(Vector2.right * offset, transform.position);
        //}
        //else if(rightRay.collider != null)
        //{
        //    _enemyBrain.Move(Vector2.left * offset, transform.position);
        //}
    }


}

    //private void DrawRay()
    //{
    //    upRay = Physics2D.Raycast(transform.position, Vector2.up, rayDistance, hitLayer);
    //    downRay = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, hitLayer);
    //    leftRay = Physics2D.Raycast(transform.position, Vector2.left, rayDistance, hitLayer);
    //    rightRay = Physics2D.Raycast(transform.position, Vector2.right, rayDistance, hitLayer);

    //    leftUpRay = Physics2D.Raycast(transform.position, new Vector2(-1, 1).normalized, 1, hitLayer);
    //    leftDownRay = Physics2D.Raycast(transform.position, new Vector2(-1, -1).normalized, 1, hitLayer);
    //    rightUpRay = Physics2D.Raycast(transform.position, new Vector2(1, 1).normalized, 1, hitLayer);
    //    rightDownRay = Physics2D.Raycast(transform.position, new Vector2(1, -1).normalized, 1, hitLayer);

    //    Debug.DrawRay(transform.position, Vector2.up * rayDistance);
    //    Debug.DrawRay(transform.position, Vector2.down * rayDistance);
    //    Debug.DrawRay(transform.position, Vector2.left * rayDistance);
    //    Debug.DrawRay(transform.position, Vector2.right * rayDistance);

    //    Debug.DrawRay(transform.position, new Vector2(-1, 1).normalized * 1);
    //    Debug.DrawRay(transform.position, new Vector2(-1, -1).normalized * 1);
    //    Debug.DrawRay(transform.position, new Vector2(1, 1).normalized * 1);
    //    Debug.DrawRay(transform.position, new Vector2(1, -1).normalized * 1);
    //}

    //private bool IsNoHitRay()
    //{
    //    bool isNoHit1 = upRay.collider == null && downRay.collider == null && leftRay.collider == null && rightRay.collider == null;
    //    bool isNoHit2 = leftUpRay.collider == null && leftDownRay.collider == null && rightDownRay.collider == null && rightUpRay.collider == null;
    //    return isNoHit1 && isNoHit2;
    //}
