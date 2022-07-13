using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Box : Item
{

    float curVel;
    public override void Reset()
    {
        curVel = Define.Player.GetComponent<AgentMovement>().CurrentVelocity;
    }

    public override void UseItem()
    {
        Debug.Log("¹Ú½º ¤Ñ¤¶¤±");
        Define.Player.GetComponent<Player>().IsBox = true;
        Define.Player.GetComponent<AgentMovement>().CurrentVelocity = 0;
        Invoke("PlayerStop", 5f);

    }
    public void PlayerStop()
    {
        Define.Player.GetComponent<Player>().IsBox = false;
        Define.Player.GetComponent<AgentMovement>().CurrentVelocity = curVel;

    }

}
