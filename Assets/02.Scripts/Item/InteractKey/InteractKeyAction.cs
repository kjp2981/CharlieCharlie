using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractKeyAction : MonoBehaviour
{

    public GameObject FKey;
    void Start()
    {
        FKey.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("On");
        if(other.gameObject.layer == 6)
            FKey.SetActive(true);
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Off");
        FKey.SetActive(false);
    }
}
