using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class TextProduction: MonoBehaviour
{
    float randomX;
    float randomY;

    void Start()
    {
        Repeating();
    }

    void Repeating()
    {
        InvokeRepeating("CreateText", 0, 0.1f);
    }

    void CreateText()
    {
        randomX = Random.Range(-19200f, 19200f);
        randomY = Random.Range(-10800f, 10800f);


        Square obj = PoolManager.Instance.Pop("Square") as Square;

        obj.transform.position = new Vector2(randomX, randomY);
        obj.transform.position = Cam.ScreenToViewportPoint(obj.transform.position);
    }
}