using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloorTxtCtrl : MonoBehaviour
{
    public TextMeshProUGUI text;
    void Start()
    {
        text.text = "<color=red>1Ãþ</color>";
    }
    void Update()
    {
        if(Define.Player.GetComponent<Player>().isFstFloor == true)
        {
            text.text = "<color=red>1F</color>";
        }
        else
        {
            text.text = "<color=red>2F</color>";
        }
    }
}
