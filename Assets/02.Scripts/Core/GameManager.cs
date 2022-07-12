using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Define;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [SerializeField]
    private PoolingListSO poolingList;

    private Scene curScene;

    private Transform playerTrm;

    private bool isSettingScene;

    private void Update()
    {
        
        
    }
    public Transform PlayerTrm
    {
        get
        {
            if(playerTrm == null)
            {
                playerTrm = Define.Player.transform;
            }
            return playerTrm;
        }
    }

    void Awake()
    {
        isSettingScene = false;
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
}
