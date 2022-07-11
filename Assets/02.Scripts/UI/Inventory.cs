using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance = null;

    public List<GameObject> items;
    public List<GameObject> keyItems;

    [SerializeField]
    private Transform itemSlotParent;
    [SerializeField]
    private Transform keySlotParent;
    [SerializeField]
    private Slot[] itemSlots;
    [SerializeField]
    private Slot[] keySlots;

    private int currentSlotIndex = 0;

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
            itemSlots[i].Item = items[i].GetComponent<Item>().ItemSO;
        }
        for(; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
        }

        i = 0;
        for (; i < keyItems.Count && i < keySlots.Length; i++)
        {
            keySlots[i].Item = keyItems[i].GetComponent<Item>().ItemSO;
        }
        for (; i < itemSlots.Length; i++)
        {
            keySlots[i].Item = null;
        }
    }

    #region Item Add % Remove
    public void AddItem(GameObject item)
    {
        if(item.GetComponent<Item>().ItemSO.isKey == true)
        {
            if(keyItems.Count < keySlots.Length)
            {
                keyItems.Add(item);
                FreshSlot();
            }
            else
            {
                Debug.Log("슬롯이 가득 차있습니다.");
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
                Debug.Log("슬롯이 가득 차있습니다.");
            }
        }
    }

    public void RemoveItem()
    {
        if(items.Count > 0)
        {
            items.RemoveAt(currentSlotIndex);
            FreshSlot();
        }
        else
        {
            Debug.Log("슬롯이 없습니다.");
        }
    }
    #endregion

    public void UseItem()
    {
        items[currentSlotIndex].GetComponent<Item>().UseItem();
        RemoveItem();
    }

    public void ChangeSlotIndex(int value)
    {
        currentSlotIndex = value;
        // UI 위치 옴기기
    }
}
