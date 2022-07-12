using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HandLight : Item
{
    private bool isUseHandLight;
    private bool isGetHandLight;

    private Light2D handLight;
    protected int handLightTimer = 30;

    private void Start()
    {
        handLight = GameObject.Find("handLight Effect").GetComponent<Light2D>();
    }

    public void GetItem()
    {
        isGetHandLight = true;
    }

    public override void Reset()
    {
        StopAllCoroutines();
    }

    IEnumerator Brightness()
    {
        while(handLightTimer>0.0f&&handLight.intensity>=0.034f)
        {
            handLight.intensity -= 0.034f;
            handLightTimer -= 1;
            yield return new WaitForSeconds(1f);
        }
    }

    public override void UseItem()
    {
        if (isGetHandLight)
        {
            if (!isUseHandLight&&handLightTimer>0)
            {
                gameObject.SetActive(true);
                StartCoroutine(Brightness());
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

}
