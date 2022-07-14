using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTxtCtrl : MonoBehaviour
{
    public GameObject OneTxt;
    public GameObject TwoTxt;
    void Start()
    {
        OneTxt.SetActive(true);
        TwoTxt.SetActive(false);
    }

    void Update()
    {
        if(Define.Player.GetComponent<Player>().isFstFloor == true)
        {
            OneTxt.SetActive(true);
            TwoTxt.SetActive(false);
        }
        else
        {
            OneTxt.SetActive(false);
            TwoTxt.SetActive(true);
        }
    }
}
