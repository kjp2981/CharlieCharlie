using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance = null;

    private Dictionary<ItemType, int> itemDic = new Dictionary<ItemType, int>();

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple GameManager is running");
        Instance = this;
    }

    public void AddItem(ItemType type)
    {
        if(itemDic.ContainsKey(type) == true)
        {
            itemDic.Add(type, 1);
        }
        else
        {
            int count = 0;
            itemDic.TryGetValue(type, out count);

            itemDic.Add(type, count + 1);
        }
    }
}
