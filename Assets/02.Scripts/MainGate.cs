using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("���� ����!");
            Debug.Log("���� �ƽ� ����");
            Debug.Log("���� �ƽ� �� ���θ޴��� �̵�");
            //SceneManager.Instance.ChangeScene("MainMenu");
        }
    }
}
