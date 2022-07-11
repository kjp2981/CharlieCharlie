using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : PoolableMono
{
    [SerializeField]
    protected ItemType type;

    public ItemType Type => type;
}
