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
    }

    // Update is called once per frame
    void Update()
    {
        //ChangeLight();
    }

    public void ChangeRedLight()
    {
        playerLight.color = new Color(0.6f, 0, 0, 1);
        handLight.color = new Color(0.6f, 0, 0, 1);
    }

    public void ChangeYelowLight()
    {
        playerLight.color = new Color(1f, 0.76f, 0.4f, 1);
        handLight.color = new Color(1f, 0.76f, 0.4f, 1);
    }
}
