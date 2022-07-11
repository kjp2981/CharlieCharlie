using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField]
    private Image image;

    private ItemSO item;
    public ItemSO Item
    {
        get => item;
        set
        {
            item = value;
            if(item != null)
            {
                image.sprite = item.itemImage;
                image.color = Color.white;
            }
            else
            {
                image.color = Color.clear;
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
