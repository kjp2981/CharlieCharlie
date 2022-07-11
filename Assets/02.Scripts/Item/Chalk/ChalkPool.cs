using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class ChalkPool : MonoBehaviour
{

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            CreateText();

    }

    void CreateText()
    {
        ChalkPoolale obj = PoolManager.Instance.Pop("Chalk") as ChalkPoolale;

        obj.transform.position = Define.Player.transform.position;
        obj.transform.position = Camera.main.ScreenToViewportPoint(obj.transform.position);
    }
}
