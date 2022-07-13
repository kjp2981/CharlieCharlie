using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Collider2D colls;

    private Collider2D doorChekcColls;

    [SerializeField]
    private float radius = 1f;
    public GameObject orangeText;

    [SerializeField]
    private bool isFlashLight = false;
    [SerializeField]
    private bool isBox = false;
    public bool IsBox
    {
        get => isBox;
        set => isBox = value;
    }

    [SerializeField]
    private GameObject handLight;

    private SpriteRenderer handLightSprite;
    [SerializeField]
    private int playerSortingOrder = 10;

    public bool isChalkOn;

    private int hitLayer;

    private int doorLayer;

    [SerializeField]
    private ItemSO item;
    private LightChange lightChange;

    public float questionTimer = 5f;
    public float chaseTimer = 0f;

    public AudioClip mainBgmClip;

    private void Start()
    {    
      lightChange = GetComponent<LightChange>();
        handLightSprite = handLight.GetComponent<SpriteRenderer>();
        hitLayer = 1 << LayerMask.NameToLayer("Item");
        doorLayer = 1 << LayerMask.NameToLayer("Door");
        
        StartCoroutine(QuestionTimer());
    }



    private void Update()
    {
        if (isFlashLight == true)
        {
            colls = Physics2D.OverlapCircle(transform.position, radius, hitLayer);
            doorChekcColls = Physics2D.OverlapCircle(transform.position, 1, doorLayer);
        }
    }

    public void CheckIsDoor()
    {
        if(doorChekcColls != null)
        {
            if(doorChekcColls.gameObject.CompareTag("Door"))
            {
                KeyCheck();
            }
        }
    }
    public void KeyCheck()
    {
        int itemsCnt = Inventory.Instance.keyItems.Count;
        DoorCtrl door = doorChekcColls.GetComponent<DoorCtrl>();
        if (Inventory.Instance.keyItems.Count > 0)
        {
            for (int i = 0; i < itemsCnt; i++)
            {
                if (door.Key.name == Inventory.Instance.keyItems[i].GetComponent<Item>().ItemSO.name)
                {
                    doorChekcColls.gameObject.GetComponent<Collider2D>().enabled = false;
                    doorChekcColls.gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0); // ���߿� ����
                    return;
                }
            }
        }
        else
            Debug.Log("���� ����");
    }

    IEnumerator QuestionTimer()
    {
        while (questionTimer > 1.0f)
        {
            questionTimer -= 1f;
            yield return new WaitForSeconds(1f);
        }
        chaseTimer = 20f;
        ButtonManager.Instance.LoadQuestion();
    }

    public void ChaseFunc()
    {
        StartCoroutine(ChaseStart());
    }

    IEnumerator ChaseStart()
    {
        lightChange.ChangeRedLight();
        switch (Inventory.Instance.keyItems.Count)
        {
            case 1:
                questionTimer = 30f;
                break;
            case 2:
                questionTimer = 25f;
                break;
            case 3:
                questionTimer = 20f;
                break;
            case 4:
                questionTimer = 15f;
                break;
            case 5:
                questionTimer = 10f;
                break;
            case 6:
                questionTimer = 5f;
                break;
            default:
                questionTimer = 30f;
                break;
        }
        while (chaseTimer > 0.0f)
        {
            chaseTimer -= 1f;
            if(chaseTimer<=0.0f)
                lightChange.ChangeYelowLight();
            yield return new WaitForSeconds(1f);
        }


        SoundManager.Instance.PlayBGMSound(mainBgmClip);
        StartCoroutine(QuestionTimer());
    }

    public bool isQuestion()
    {
        return questionTimer == 0.0f;
    }

    public void GetItem()
    {
        if (isFlashLight == true)
        {
            if (colls != null)
            {
                Debug.Log($"{colls.name}");
                Inventory.Instance.AddItem(colls.gameObject);
                colls.gameObject.SetActive(false);
            }
        }
    }

    public void GetHandLight()
    {
        if(handLight.activeSelf==false)
            handLight.SetActive(true);
        else
            handLight.SetActive(false);
    }

    public void rotateHandLight(Vector2 pos)
    {
        if (pos!=Vector2.zero)
        {
            float angle = Mathf.Atan2(pos.y, -pos.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
            handLight.transform.rotation = Quaternion.Slerp(handLight.transform.rotation, rotation, 10 * Time.deltaTime);

            if(angle > 90f || angle < -90f)
            {
                handLightSprite.flipY = true;
            }
            else
            {
                handLightSprite.flipY = false;
            }

            if(angle > 0 && angle < 180)
            {
                handLightSprite.sortingOrder = playerSortingOrder - 1;
            }
            else
            {
                handLightSprite.sortingOrder = playerSortingOrder + 1;
            }
        }
    }

    private RaycastHit2D ray;


    [SerializeField]
    private float rayDistance = 1;
    [SerializeField]
    private LayerMask rayHitLayer;

    


#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.color = Color.white;

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 1);
        Gizmos.color = Color.white;
    }
#endif
}
