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
        handLight = GameObject.Find("handLight").GetComponent<Light2D>();
        ChangeLight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeLight()
    {
        playerLight.color = Color.red;
        handLight.color = Color.red;
    }
}
