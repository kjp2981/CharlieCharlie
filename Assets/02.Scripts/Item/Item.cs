using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField]
    private ItemSO itemSO;

    public ItemSO ItemSO => itemSO;

    public abstract void UseItem();
}
