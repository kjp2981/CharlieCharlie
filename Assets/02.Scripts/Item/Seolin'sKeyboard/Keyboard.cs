using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Keyboard : Item
{
    public GameObject text;
    float curTime;
    public override void Reset()
    {
    }

    public override void UseItem()
    {
        curTime = 0f;
        KeyboardTxt text = PoolManager.Instance.Pop("keyboardTxt") as KeyboardTxt;

        text.transform.position = Define.Player.transform.position + new Vector3(0,1,0);

        for (float i = curTime; i < 5f; i+=Time.time)
        {

        }
        Debug.Log("delete");

    }

    


    

}
