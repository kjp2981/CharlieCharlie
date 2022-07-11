using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemSO itemSO;

    public ItemSO ItemSO => itemSO;
}
