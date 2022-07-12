using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightChange : MonoBehaviour
{
    private Light2D playerLight;
    private Light2D handLight;
    // Start is called before the first frame update
    void Start()
    {
        playerLight = GameObject.Find("Light").GetComponent<Light2D>();
        handLight = GameObject.Find("handLight Effect").GetComponent<Light2D>();
        ChangeLight();
    }

    // Update is called once per frame
    void Update()
    {
        //ChangeLight();
    }

    void ChangeLight()
    {
        playerLight.color = new Color(0.6f, 0, 0, 1);
        handLight.color = new Color(0.6f, 0, 0, 1);
        //if(handLight.intensity>=0.034f)
        //{
        //    playerLight.intensity -= 0.034f;
        //    handLight.intensity -= 0.034f;
        //}
    }
}
