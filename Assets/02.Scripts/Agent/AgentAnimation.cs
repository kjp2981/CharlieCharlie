using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnimation : MonoBehaviour
{
    private SpriteRenderer spriteRenderer = null;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    public void LookAt(Vector2 input)
    {
        if(input.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(input.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
