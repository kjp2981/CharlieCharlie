using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
public class OneToTwo : MonoBehaviour
{

    public Transform SndFloorPos;
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("2ÃþÀ¸·Î");
            Define.Player.transform.position = SndFloorPos.position;
        }
    }
}
