using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CutSceneManager.Instance.IsCutSceneChange(true);
            CutSceneManager.Instance.PlayEndingCutscene();
        }
    }
}
