using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private Collider2D colls;
    [SerializeField]
    private float radius = 1f;
    public GameObject orangeText;

    [SerializeField]
    private bool isFlashLight = false;

    [SerializeField]
    private GameObject handLight;

    private SpriteRenderer handLightSprite;
    [SerializeField]
    private int playerSortingOrder = 10;

    public bool isChalkOn;

    private int hitLayer;

    private ButtonManager buttonManager;
    private LightChange lightChange;

    public float questionTimer = 5f;
    public float chaseTimer = 0f;

    private void Start()
    {
        lightChange = GetComponent<LightChange>();
        buttonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
        handLightSprite = handLight.GetComponent<SpriteRenderer>();
        hitLayer = 1 << LayerMask.NameToLayer("Item");
        StartCoroutine(QuestionTimer());
    }

    private void Update()
    {
        if (isFlashLight == true)
        {
            colls = Physics2D.OverlapCircle(transform.position, radius, hitLayer);
        }

        if (colls != null)
        {
            Debug.Log("아이템 있음!");
        }
    }

    IEnumerator QuestionTimer()
    {
        while (questionTimer > 1.0f)
        {
            questionTimer -= 1f;
            yield return new WaitForSeconds(1f);
        }
        chaseTimer = 20f;
        buttonManager.LoadQuestion();
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

        StartCoroutine(QuestionTimer());
    }

    public void GetItem()
    {
        if (colls != null)
        {
            Debug.Log($"{colls.name}");
            Inventory.Instance.AddItem(colls.gameObject);
            colls.gameObject.SetActive(false);
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
            //if ((handLight.transform.rotation.z > 90 && handLight.transform.rotation.z < 180) || (handLight.transform.rotation.z >-180&& handLight.transform.rotation.z < -90))
            //{
            //    handLight.transform.position = new Vector3(handLight.transform.position.x, handLight.transform.position.y, 0f);
            //    handLightSprite.flipY = false;
            //}
            //else
            //{
            //    handLight.transform.position = new Vector3(handLight.transform.position.x, handLight.transform.position.y, 1f);
            //    handLightSprite.flipY = true;
            //}

            float angle = Mathf.Atan2(pos.y, -pos.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
            handLight.transform.rotation = Quaternion.Slerp(handLight.transform.rotation, rotation, 10 * Time.deltaTime);

            //if(handLight.transform.rotation.z > 90 || handLight.transform.rotation.z < -90)
            //{
            //    handLight.transform.position = new Vector3(handLight.transform.position.x, handLight.transform.position.y, 0f);
            //    handLightSprite.flipY = false;
            //}
            //else
            //{
            //    handLight.transform.position = new Vector3(handLight.transform.position.x, handLight.transform.position.y, 1f);
            //    handLightSprite.flipY = true;
            //}

            if(angle > 90f || angle < -90f)
            {
                handLightSprite.flipY = true;
            }
            else
            {
                handLightSprite.flipY = false;
            }

            if(angle > 0 && angle < 270)
            {
                handLightSprite.sortingOrder = playerSortingOrder + 1;
            }
            else
            {
                handLightSprite.sortingOrder = playerSortingOrder - 1;
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.color = Color.white;
    }
#endif
}
