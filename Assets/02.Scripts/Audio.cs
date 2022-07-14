using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Audio : PoolableMono
{
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
        StartCoroutine(ReturnAudio(clip.length));
    }

    private IEnumerator ReturnAudio(float time)
    {
        yield return new WaitForSeconds(time);
        PoolManager.Instance.Push(this);
    }

    public override void Reset()
    {
        audioSource.pitch = 1;
    }
}
