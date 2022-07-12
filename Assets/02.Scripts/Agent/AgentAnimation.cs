using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnimation : MonoBehaviour
{
    private Animator animator = null;

    private readonly int hashH = Animator.StringToHash("h");
    private readonly int hashV = Animator.StringToHash("v");
    private readonly int hashIsMove = Animator.StringToHash("isMove");

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void MoveAnim(Vector2 input)
    {
        animator.SetFloat(hashH, input.x);
        animator.SetFloat(hashV, input.y);

        animator.SetBool(hashIsMove, input != Vector2.zero);
    }
}
