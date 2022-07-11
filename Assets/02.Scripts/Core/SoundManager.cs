using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance = null;

    void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple SoundManager is running");
        Instance = this;
    }

    public void PlaySound(AudioClip clip)
    {
        Audio audio = PoolManager.Instance.Pop("Audio") as Audio;
        audio.PlaySound(clip);
    }
}
