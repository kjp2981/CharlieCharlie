using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    private static GameObject player = null;

    public static GameObject Player
    {
        get
        {
            if(player == null)
            {
                player = GameObject.FindWithTag("Player");
            }
            return player;
        }
    }
}
