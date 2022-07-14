using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentMovement : MonoBehaviour
{
    private Rigidbody2D rigid;
    public bool isAdrenaline, isAdrenalining = false;
    public bool isIdBag = false;
    [SerializeField]
    private MovementDataSO moveData;

    private float currentVelocity;
    public float CurrentVelocity
    {
        get => currentVelocity;
        set => currentVelocity = value;
    }
    private float normalVelocity;
    private float adrenalineVelocity;
    private float idBagVelocity;
    private Vector2 moveDirection;

    public UnityEvent<float> OnVelocityChange;
    private Player player => Define.Player.GetComponent<Player>();

    //public ButtonManager buttonManager;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        normalVelocity = currentVelocity;
        adrenalineVelocity = currentVelocity * 1.5f;
        idBagVelocity = currentVelocity * 1.05f;
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

        if (CutSceneManager.Instance.IsCutscene == false)
        {
            if (!player.IsBox)
                rigid.velocity = moveDirection * currentVelocity;
            else
                rigid.velocity = Vector2.zero;
        }

        if (isAdrenaline)
        {
            StartCoroutine(AdSpeedUP());
        }

        if(isIdBag)
        {
            IdSpeedUP();
        }

    }

    public void IdSpeedUP()
    {
        currentVelocity = idBagVelocity;
    }
    public IEnumerator AdSpeedUP()
    {
        if(isAdrenaline)
        {
            currentVelocity = adrenalineVelocity;
            isAdrenalining = true;
            isAdrenaline = false;
            Debug.Log($"������. ���� �ӵ� : {currentVelocity}");

        }
        yield return new WaitForSeconds(5);
        isAdrenalining = false;
        Debug.Log($"��������. ���� �ӵ� : {currentVelocity}");
        currentVelocity = normalVelocity;

    }

    public void ResetVelcity()
    {
        currentVelocity = 0f;
        rigid.velocity = Vector2.zero;
    }
}
