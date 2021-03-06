using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance = null;

    [SerializeField]
    private Slider bgmSlider;
    [SerializeField]
    private Slider effectSlider;

    [SerializeField]
    private AudioSource bgmAudioSource = null;

    [SerializeField]
    private float soundRandomness = 0.2f;

    void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple SoundManager is running");
        Instance = this;
    }

    public void PlayBGMSound(AudioClip clip)
    {
        bgmAudioSource.Stop();
        bgmAudioSource.clip = clip;
        bgmAudioSource.Play();
    }

    public void PlaySound(AudioClip clip)
    {
        Audio audio = PoolManager.Instance.Pop("Audio") as Audio;
        audio.GetComponent<AudioSource>().volume = effectSlider.value;
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

    public void BgmValue()
    {
        bgmAudioSource.volume = bgmSlider.value;
    }

    public void Update()
    {
        BgmValue();
    }
}
