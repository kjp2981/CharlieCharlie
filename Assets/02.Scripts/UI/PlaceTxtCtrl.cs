using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlaceTxtCtrl : MonoBehaviour
{
    public TextMeshProUGUI placeTxt;
    public string textString;
    private void Start()
    {
        textString = "";
        placeTxt.text = textString;
    }

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Root"))
        {
            placeTxt.text = "<color=red>����</color>";
        }
        for (int i = 1; i < 5; i++)
        {
            if (collision.gameObject.CompareTag($"Class{i}"))
            {
                placeTxt.text = $"<color=red>{i}�� ����</color>";
            }
        }
        if (collision.gameObject.CompareTag("BathRoom1"))
        {
            placeTxt.text = "<color=red>ȭ���</color>";
        }
        if (collision.gameObject.CompareTag("Teacher'sRoom"))
        {
            placeTxt.text = "<color=red>������</color>";
        }
        if (collision.gameObject.CompareTag("MedicalRoom"))
        {
            placeTxt.text = "<color=red>���ǽ�</color>";
        }
        if (collision.gameObject.CompareTag("ScienceRoom"))
        {
            placeTxt.text = "<color=red>���н�</color>";
        }
        if (collision.gameObject.CompareTag("ComputerRoom"))
        {
            placeTxt.text = "<color=red>��ǻ�ͽ�</color>";
        }
        if (collision.gameObject.CompareTag("PrincipalRoom"))
        {
            placeTxt.text = "<color=red>�����</color>";
        }
        if (collision.gameObject.CompareTag("Library"))
        {
            placeTxt.text = "<color=red>������</color>";
        }
        if (collision.gameObject.CompareTag("MusicRoom"))
        {
            placeTxt.text = "<color=red>���ǽ�</color>";
        }
        if (collision.gameObject.CompareTag("ZZamRoom"))
        {
            placeTxt.text = "<color=red>â��</color>";
        }
        if (collision.gameObject.CompareTag("SercurityRoom"))
        {
            placeTxt.text = "<color=red>����</color>";
        }
    }


}
