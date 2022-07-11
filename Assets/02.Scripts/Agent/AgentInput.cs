using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementKeyPress = null;
    public UnityEvent OnInteractionKeyPress = null; // F버튼 눌를때

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.F))
        {
            Interaction();
        }
    }

    void Move()
    {
        OnMovementKeyPress?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }

    void Interaction()
    {
        OnInteractionKeyPress?.Invoke();
    }
}
