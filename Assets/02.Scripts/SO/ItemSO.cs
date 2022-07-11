using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/UI/Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public bool isKey;
}
