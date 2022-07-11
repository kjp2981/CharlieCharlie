using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using static Define;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    private float shakeOffset = 3f;
    [SerializeField]
    private float shakeTime = 1f;

    public IEnumerator Shake()
    {
        VCam.GetComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 3f;
        yield return new WaitForSeconds(shakeTime);
        VCam.GetComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
    }
}