using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentMovement : MonoBehaviour
{
    private Rigidbody2D rigid;
    public bool isAdrenaline, isAdrenalining;

    [SerializeField]
    private MovementDataSO moveData;

    private float currentVelocity;
    private Vector2 moveDirection;

    public UnityEvent<float> OnVelocityChange;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Movement(Vector2 input)
    {
        if(input.sqrMagnitude > 0)
        {
            if(Vector2.Dot(input, moveDirection) < 0)
            {
                currentVelocity = 0f;
            }
            moveDirection = input.normalized;
        }
        currentVelocity = CalculateSpeed(input);
    }

    private float CalculateSpeed(Vector2 input)
    {
        if (input.sqrMagnitude > 0)
        {
            currentVelocity += moveData.acceleration * Time.deltaTime;
        }
        else
        {
            currentVelocity -= moveData.deAcceleration * Time.deltaTime;
        }

        return Mathf.Clamp(currentVelocity, 0, moveData.maxSpeed);
    }

    private void FixedUpdate()
    {
        OnVelocityChange?.Invoke(currentVelocity);
        
        rigid.velocity = moveDirection * currentVelocity;

        if(isAdrenaline)
        {
            StartCoroutine(SpeedUP());
        }
    }
    public IEnumerator SpeedUP()
    {
        if(isAdrenaline)
        {
            currentVelocity *= 1.5f;
            isAdrenalining = true;
            isAdrenaline = false;
            Debug.Log($"»¡¶óÁü. ÇöÀç ¼Óµµ : {currentVelocity}");

        }
        yield return new WaitForSeconds(5);
        isAdrenalining = false;
        Debug.Log($"»¡¶óÁø³¡. ÇöÀç ¼Óµµ : {currentVelocity}");
        currentVelocity /= 1.5f;

    }
}
