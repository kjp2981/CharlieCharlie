using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlaceTxtCtrl : MonoBehaviour
{
    public TextMeshPro placeTxt;
    public string textString;
    private void Start()
    {
        textString = "";
        placeTxt.text = textString;
    }

    private void Update()
    {
        placeTxt.transform.position = Define.Player.transform.position + new Vector3(8, 5, 0);
    }
    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.gameObject.CompareTag("Root"))
        {
            placeTxt.text = "<color=red>복도</color>";
        }
        for (int i = 1; i < 5; i++)
        {
            if (collision.gameObject.CompareTag($"Class{i}"))
            {
                placeTxt.text = $"<color=red>{i}반 교실</color>";
            }
        }

    }


}
