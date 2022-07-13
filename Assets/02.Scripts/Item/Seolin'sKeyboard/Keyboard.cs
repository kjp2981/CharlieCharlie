using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Keyboard : Item
{
    public float moveSpeed = 1f;
    private Vector3 startPos;
    public override void Reset()
    {
    }

    public override void UseItem()
    {
        KeyboardTxt obj = PoolManager.Instance.Pop("keyboardTxt") as KeyboardTxt;

        Vector3 pos = Define.Player.transform.position;
        pos.z = 900;
        obj.transform.position = pos;
        Sequence seq = DOTween.Sequence();
        seq.Append(obj.transform.DOMoveY(startPos.y + 2, 1f));
        seq.Join(obj.GetComponent<TextMeshPro>().DOFade(0, 1f));
        seq.AppendCallback(() => PoolManager.Instance.Push(obj));

    }

    


    

}
