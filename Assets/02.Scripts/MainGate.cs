using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("정문 도착!");
            Debug.Log("엔딩 컷신 시작");
            Debug.Log("엔딩 컷신 후 메인메뉴로 이동");
            //SceneManager.Instance.ChangeScene("MainMenu");
        }
    }
}
