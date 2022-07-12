using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : Item
{
    public override void Reset()
    {
        StopAllCoroutines();
    }

    public override void UseItem()
    {
        //handLightTimer = 30;
    }
}
