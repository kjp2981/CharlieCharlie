using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
public class IndoorShoesBag : Item
{
    private bool IdspeedUp;

    private void Start()
    {
        IdspeedUp = Define.Player.GetComponent<AgentMovement>().isIdBag;
    }
    public override void UseItem()
    {
        IdspeedUp = true;
        Define.Player.GetComponent<AgentMovement>().isIdBag = IdspeedUp;
    }

    public override void Reset()
    {
    }
}
