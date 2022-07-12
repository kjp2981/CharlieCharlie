using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : HandLight
{
    public override void Reset()
    {
        StopAllCoroutines();
    }

    public override void UseItem()
    {
        handLightTimer = 30;
    }
}
