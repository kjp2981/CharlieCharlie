using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCtrl : MonoBehaviour
{
    [SerializeField]
    private ItemSO key;

    public ItemSO Key => key;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.F))
            {
                // �ؽ�Ʈ�� "F �� ����" Ȱ��ȭ
                
            }
        }
        
    }

}
