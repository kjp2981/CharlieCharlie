using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class AdrenalinePistol : Item
{
    private bool isAd;
    public override void UseItem()
    {
        if (Define.Player.GetComponent<AgentMovement>().isAdrenalining == false)
            isAd = !isAd;
    }
}
