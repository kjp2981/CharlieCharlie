using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PoolingPair
{
    public PoolableMono prefab;
    public int poolCnt;
}


[CreateAssetMenu(menuName = "SO/System/PoolingList")]
public class PoolingListSO : ScriptableObject
{
    public List<PoolingPair> list;
}