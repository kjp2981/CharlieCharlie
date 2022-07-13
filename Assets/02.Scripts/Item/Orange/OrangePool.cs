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
        Debug.Log("±Ö »ç¿ëÇÔ");
        OrangeTextPool obj = PoolManager.Instance.Pop("OrangeText") as OrangeTextPool;
        Vector3 pos = Define.Player.transform.position;
        pos.z = 900;
        obj.transform.position = pos;
        Sequence seq = DOTween.Sequence();
        seq.Append(obj.transform.DOMoveY(startPos.y + 2, 1f));
        seq.Join(obj.GetComponent<TextMeshPro>().DOFade(0, 1f));
        seq.AppendCallback(() => PoolManager.Instance.Push(obj));
    }
}