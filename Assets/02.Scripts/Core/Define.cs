using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    private static CinemachineVirtualCamera vCam = null;

    public static CinemachineVirtualCamera VCam
    {
        get
        {
            if(vCam == null)
            {
                vCam = GameObject.FindWithTag("VCam").GetComponent<CinemachineVirtualCamera>();
            }
            return vCam;
        }
    }
}
