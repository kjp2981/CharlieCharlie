using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
public class OneToTwo : MonoBehaviour
{

    public Transform SndFloorPos;

    public GameObject StopCol;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("Charlie"))
        {
            Define.Player.GetComponent<Player>().isFstFloor = false;
            Debug.Log("2ÃþÀ¸·Î");
            Define.Player.transform.position = SndFloorPos.position;
            StartCoroutine(StopDelay());
        }
    }
    IEnumerator StopDelay()
    {
        StopCol.SetActive(true);
        yield return new WaitForSeconds(3);
        StopCol.SetActive(false);
    }
}
