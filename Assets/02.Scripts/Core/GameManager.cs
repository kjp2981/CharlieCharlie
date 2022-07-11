using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [SerializeField]
    private PoolingListSO poolingList;
    [SerializeField]
    private AudioClip clip;

    void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple GameManager is running");
        Instance = this;

        PoolManager.Instance = new PoolManager(transform);

        CreatePool();
    }

    private void CreatePool()
    {
        foreach(PoolingPair pair in poolingList.list)
        {
            PoolManager.Instance.CreatePool(pair.prefab, pair.poolCnt);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            SoundManager.Instance.PlaySound(clip);
    }
}
