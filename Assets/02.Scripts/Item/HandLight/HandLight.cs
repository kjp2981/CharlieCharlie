using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HandLight : MonoBehaviour
{
    public Light2D handLight;
    public float handLightTimer = 30;

    private void OnEnable()
    {
        StopAllCoroutines();

        StartCoroutine(Brightness());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator Brightness()
    {
        while (handLightTimer > 0.0f && handLight.intensity >= 0.0034f)
        {
            if(!ButtonManager.Instance.CharlieTime)
            {
                handLight.intensity -= 0.0034f;
                handLightTimer -= 0.01f;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

}
