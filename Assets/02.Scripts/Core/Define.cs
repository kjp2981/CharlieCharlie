using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    private static Camera cam = null;
    private static CinemachineVirtualCamera vCam = null;
    private static GameObject player = null;
    private static PathFinding pathFinding = null;

    public static Camera Cam
    {
        get
        {
            if(cam == null)
            {
                cam = Camera.main;
            }
            return cam;
        }
    }

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


    public static GameObject Player
    {
        get
        {
            if(player == null)
            {
                player = GameObject.FindWithTag("Player");
            }
            return player;
        }
    }

    public static PathFinding PathFinding
    {
        get
        {
            if(pathFinding == null)
            {
                pathFinding = GameObject.FindObjectOfType<PathFinding>();
            }
            return pathFinding;
        }
    }
}
