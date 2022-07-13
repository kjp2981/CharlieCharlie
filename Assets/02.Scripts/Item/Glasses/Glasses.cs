using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Glasses : Item
{
    private Light2D playerLight;
    public override void Reset()
    {
    }

    public override void UseItem()
    {
        playerLight = GameObject.Find("Light").GetComponent<Light2D>();
        playerLight.pointLightOuterRadius *= 1.5f; 
    }

}
