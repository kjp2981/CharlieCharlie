using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;

    void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple GameManager is running");
        Instance = this;
    }
}
