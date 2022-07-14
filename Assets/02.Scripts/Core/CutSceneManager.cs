using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneManager : MonoBehaviour
{
    public static CutSceneManager Instance = null;

    public PlayableDirector director;

    private bool isCutscene = false;
    public bool IsCutscene => isCutscene;

    void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple GameManager is running");
        Instance = this;
    }

    public void IsCutSceneChange(bool value)
    {
        isCutscene = value;
    }
}
