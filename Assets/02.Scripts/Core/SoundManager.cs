using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance = null;

    [SerializeField]
    private float soundRandomness = 0.2f;

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

    public void PlaySoundRandomness(AudioClip clip)
    {
        StartCoroutine(PlaySoundRandomnessCoroutine(clip));
    }

    private IEnumerator PlaySoundRandomnessCoroutine(AudioClip clip)
    {
        yield return new WaitForSeconds(Random.Range(-soundRandomness, soundRandomness));
        PlaySound(clip);
    }
}
