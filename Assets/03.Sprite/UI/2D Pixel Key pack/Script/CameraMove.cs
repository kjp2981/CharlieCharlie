using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float Speed;
    public float Ampl;

    void Update()
    {
        transform.Translate(transform.right * Mathf.Cos(Time.time / Ampl) * Time.deltaTime * Speed);
    }
}
