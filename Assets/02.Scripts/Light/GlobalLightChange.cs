using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightChange : MonoBehaviour
{
    private Light2D globalLight;

    void Start()
    {
        globalLight = GetComponent<Light2D>();
    }

    public void GlobaoLightChange(bool isWhite)
    {
        if(isWhite == true)
        {
            globalLight.color = Color.white;
        }
        else
        {
            float num = 70f / 255f;
            globalLight.color = new Color(num, num, num, 1);
        }
    }
}
