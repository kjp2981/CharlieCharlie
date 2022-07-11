using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrangePool : Item
{
    public IEnumerator NTimeWork(float duration)
    {
        float time = 0.0f;

        while (time < 3.0f)
        {
            time += Time.deltaTime / duration;

            transform.Translate(Vector3.up);
            yield return null;
        }
    }

    public override void UseItem()
    {

        transform.position = Define.Player.transform.position;
        StartCoroutine(NTimeWork(3));
    }
}

