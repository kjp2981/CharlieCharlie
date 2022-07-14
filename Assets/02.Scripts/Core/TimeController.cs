using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public void Timescale(float value)
    {
        Time.timeScale = value;
    }
}
