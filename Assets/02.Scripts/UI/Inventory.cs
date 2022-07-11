using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemSO> items;

    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private Slot[] slots;

    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }

    private void Awake()
    {
        FreshSlot();
    }

    public void FreshSlot()
    {
        int i = 0;
        for(; i < items.Count && i < slots.Length; i++)
        {
            slots[i].Item = items[i];
        }
        for(; i < slots.Length; i++)
        {
            slots[i].Item = null;
        }
    }

    public void AddItem(ItemSO item)
    {
        if(items.Count < slots.Length)
        {
            items.Add(item);
            FreshSlot();
        }
        else
        {
            Debug.Log("½½·ÔÀÌ °¡µæ Â÷ÀÖ½À´Ï´Ù.");
        }
    }
}
