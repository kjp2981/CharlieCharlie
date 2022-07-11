using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Collider2D colls;
    [SerializeField]
    private float radius = 1f;
    public GameObject orangeText;

    [SerializeField]
    private bool isFlashLight = false;

    private int hitLayer;

    private void Start()
    {
        hitLayer = 1 << LayerMask.NameToLayer("Item");
    }

    private void Update()
    {
        if(isFlashLight == true)
        {
            colls = Physics2D.OverlapCircle(transform.position, radius, hitLayer);
        }

        if(colls != null)
        {
            Debug.Log("아이템 있음!");
        }
    }

    public void GetItem()
    {
        if (colls != null)
        {
            Debug.Log($"{colls.name}");
            Inventory.Instance.AddItem(colls.GetComponent<Item>().ItemSO);
            colls.gameObject.SetActive(false);
        }
    }


#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.color = Color.white;
    }
#endif
}
