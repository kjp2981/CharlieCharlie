using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Battery : Item
{
    public override void Reset()
    {
        StopAllCoroutines();
    }

    public override void UseItem()
    {
        Debug.Log("πË≈Õ∏Æ æ∏");
        Light2D handLight = Define.Player.transform.Find("handLight/handLight Effect").GetComponent<Light2D>();
        handLight.intensity = 1f;
    }
}
