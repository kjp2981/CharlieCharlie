using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAction : AIAction
{
    [SerializeField]
    private LayerMask hitLayer;
    [SerializeField]
    private float rayDistance = 1f;

    RaycastHit2D upRay; // ��
    RaycastHit2D downRay; // �Ʒ�
    RaycastHit2D leftRay; // ����
    RaycastHit2D rightRay; // ������

    [System.Obsolete]
    RaycastHit2D leftUpRay; // ���� �� �밢��
    [System.Obsolete]
    RaycastHit2D rightUpRay; // ������ �� �밢��
    [System.Obsolete]
    RaycastHit2D leftDownRay; // ���� �Ʒ� �밢��
    [System.Obsolete]
    RaycastHit2D rightDownRay; // ������ �Ʒ� �밢��

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
