using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private Image currentImage = null;
    private int currentSlotIndex = 0;

    private RectTransform initTransform;

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

        initTransform = currentImage.rectTransform;
        FreshSlot();
    }

    private void Update()
    {
        switch (currentSlotIndex)
        {
            case 0:
                currentImage.rectTransform.position = new Vector2(80, initTransform.position.y);
                break;
            case 1:
                currentImage.rectTransform.position = new Vector2(190, initTransform.position.y);
                break;
            case 2:
                currentImage.rectTransform.position = new Vector2(300, initTransform.position.y);
                break;
            case 3:
                currentImage.rectTransform.position = new Vector2(410, initTransform.position.y);
                break;
            case 4:
                currentImage.rectTransform.position = new Vector2(520, initTransform.position.y);
                break;
            default:
                break;
        }
        
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

    public void RemoveItem()
    {
        if(items.Count > 0)
        {
            items.RemoveAt(currentSlotIndex);
            FreshSlot();
        }
        else
        {
            Debug.Log("½½·ÔÀÌ ¾ø½À´Ï´Ù.");
        }
    }
    #endregion

    public void UseItem()
    {
        if (items.Count > 0)
        {
            if (items[currentSlotIndex] != null)
            {
                items[currentSlotIndex].GetComponent<Item>().UseItem();
                RemoveItem();
            }
        }
    }

    public void ChangeSlotIndex(int value)
    {
        currentSlotIndex = value;
        // UI À§Ä¡ ¿È±â±â
    }

}
