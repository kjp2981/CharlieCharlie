using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class ChalkPool : Item
{
    public float moveSpeed = 20f;
    private Vector3 startPos;

    public Rigidbody2D chalkRigidbody;
    public GameObject ChalkObj;
    private bool isChalkOn;
    Vector3 dir;


    private void Start()
    {
        isChalkOn = false;
        startPos = Define.Player.transform.position;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            dir = Input.mousePosition - startPos;
            isChalkOn = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PoolManager.Instance.Push(this);
    }

    public override void UseItem()
    {
        if(isChalkOn)
        {
            chalkRigidbody.AddForce(dir * 100f,ForceMode2D.Impulse);
        }
    }

    
    public override void Reset()
    {
    }
}
