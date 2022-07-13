using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoToOne : MonoBehaviour
{
    public Transform FstFloorPos;
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("1ÃþÀ¸·Î");
            Define.Player.transform.position = FstFloorPos.position;
        }
    }
}
