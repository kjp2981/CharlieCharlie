using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Define;
using DG.Tweening;

public class OrangePool : Item
{
    public override void Reset()
    {

    }
    public float moveSpeed = 1f;
    private Vector3 startPos;
    private void Start()
    {
        startPos = Define.Player.transform.position + new Vector3(0, 100);
    }

    public override void UseItem()
    {
        Debug.Log("�� �����");
        OrangeTextPool obj = PoolManager.Instance.Pop("OrangeText") as OrangeTextPool;
        obj.transform.position = Define.Player.transform.position;
        Sequence seq = DOTween.Sequence();
        seq.Append(obj.transform.DOMoveY(startPos.y + 2, .3f));
        seq.Join(obj.GetComponent<TextMeshPro>().DOFade(0, .3f));
        seq.AppendCallback(() => PoolManager.Instance.Push(obj));
    }
}