using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class Target : MonoBehaviour
{
    public void Update()
    {
        Define.PathFinding.touchOrigin = (Vector2)transform.position;
    }
}