using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementKeyPress = null;
    public UnityEvent OnInteractionKeyPress = null; // F버튼 눌를때
    public UnityEvent<int> OnChangeItem = null; // 숫자키 1, 2, 3.. 눌렀을 때
    public UnityEvent OnUseItem = null; // 마우스 좌클릭 아마도
    public UnityEvent OnHandLight = null; // 손전등 이벤트
    

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.F))
        {
            Interaction();
        }
        if (Input.GetMouseButtonDown(0))
        {
            UseItem();
        }
        if (Input.GetMouseButtonDown(1))
        {
            UseHandLight();
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

    void UseItem()
    {
        OnUseItem?.Invoke();
    }

    void ChangeItem(int value)
    {
        OnChangeItem?.Invoke(value);
    }

    void UseHandLight()
    {
        OnHandLight?.Invoke();
    }

    private void OnGUI()
    {
        if (Event.current.isKey)
        {
            switch (Event.current.keyCode)
            {
                case KeyCode.Alpha1:
                    if (Event.GetEventCount() == 1)
                    {
                        Debug.Log("input 1");
                        ChangeItem(0);
                    }
                    break;
                case KeyCode.Alpha2:
                    if (Event.GetEventCount() == 1)
                    {
                        Debug.Log("input 2");
                        ChangeItem(1);
                    }
                    break;
                case KeyCode.Alpha3:
                    if (Event.GetEventCount() == 1)
                    {
                        Debug.Log("input 3");
                        ChangeItem(2);
                    }
                    break;
                case KeyCode.Alpha4:
                    if (Event.GetEventCount() == 1)
                    {
                        Debug.Log("input 4");
                        ChangeItem(3);
                    }
                    break;
                case KeyCode.Alpha5:
                    if (Event.GetEventCount() == 1)
                    {
                        Debug.Log("input 5");
                        ChangeItem(4);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
