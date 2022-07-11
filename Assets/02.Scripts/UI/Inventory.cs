using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance = null;

    public List<ItemSO> items;
    public List<ItemSO> keyItems;

    [SerializeField]
    private Transform itemSlotParent;
    [SerializeField]
    private Transform keySlotParent;
    [SerializeField]
    private Slot[] itemSlots;
    [SerializeField]
    private Slot[] keySlots;

    private void OnValidate()
    {
        itemSlots = itemSlotParent.GetComponentsInChildren<Slot>();
        keySlots = keySlotParent.GetComponentsInChildren<Slot>();
    }

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple GameManager is running");
        Instance = this;

        FreshSlot();
    }

    public void FreshSlot()
    {
        int i = 0;
        for(; i < items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = items[i];
        }
        for(; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
        }

        i = 0;
        for (; i < keyItems.Count && i < keySlots.Length; i++)
        {
            keySlots[i].Item = keyItems[i];
        }
        for (; i < itemSlots.Length; i++)
        {
            keySlots[i].Item = null;
        }
    }

    public void AddItem(ItemSO item)
    {
        if(item.isKey == true)
        {
            if(keyItems.Count < keySlots.Length)
            {
                keyItems.Add(item);
                FreshSlot();
            }
            else
            {
                Debug.Log("½½·ÔÀÌ °¡µæ Â÷ÀÖ½À´Ï´Ù.");
            }
        }
        else
        {
            if (items.Count < itemSlots.Length)
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
}
