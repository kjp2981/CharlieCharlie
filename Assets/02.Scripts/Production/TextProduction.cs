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
        //Repeating();
        StartCoroutine(CreateText());
    }

    void Repeating()
    {
        InvokeRepeating("CreateText", 0, 0.1f);
    }

    public IEnumerator CreateText()
    {
        for (int i = 0; i < 1000; i++)
        {
            randomX = Random.Range(-19200f, 19200f);
            randomY = Random.Range(-10800f, 10800f);


            Square obj = PoolManager.Instance.Pop("Square") as Square;

            obj.transform.position = new Vector2(randomX, randomY);
            obj.transform.position = Cam.ScreenToViewportPoint(obj.transform.position);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
