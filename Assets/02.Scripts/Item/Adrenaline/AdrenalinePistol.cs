using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class AdrenalinePistol : Item
{
    private bool isAd;
    

    private void Start()
    {
        
        isAd = Define.Player.GetComponent<AgentMovement>().isAdrenaline;
    }
    public override void UseItem()
    {
        if (Define.Player.GetComponent<AgentMovement>().isAdrenalining == false)
            isAd = !isAd;
        Define.Player.GetComponent<AgentMovement>().isAdrenaline = isAd;
    }

    public override void Reset()
    {
    }
}
