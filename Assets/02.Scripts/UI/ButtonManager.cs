using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Define;

public class ButtonManager : MonoBehaviour
{
    public List<Sprite> sprite = new List<Sprite>();

    public Image iamgeOne;
    public Image imageTwo;
    public Image imageThree;

    public bool CharlieTime = false;

    public Transform pencil;

    public Transform[] YesTrs;

    public Transform[] NoTrs;

    float angle;
    public bool rotatePencil;

    public int curCount = 0;
    public int maxCount = 12;

    public static ButtonManager Instance = null;

    public GameObject SettingCanvas;
    public GameObject QuestionCanvas;
    public GameObject AnswerCanvas;

    private Player player;

    public AudioClip mainBgmClip;
    public AudioClip questionClip;
    public AudioClip chaseClip;
    public AudioClip gameOverClip;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple GameManager is running");
        Instance = this;
    }

    private void Start()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 0)
        {
            SoundManager.Instance.PlayBGMSound(questionClip);
        }
        else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 1)
        {
            player = Define.Player.GetComponent<Player>();
            SoundManager.Instance.PlayBGMSound(mainBgmClip);
        }
        else if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 2)
        {
            SoundManager.Instance.PlayBGMSound(gameOverClip);
        }
        //ShuffleList(sprite);
    }

    private void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (CharlieTime)
                pencil.transform.rotation = Quaternion.Slerp(pencil.transform.rotation, Quaternion.AngleAxis(angle - 90, Vector3.forward), 0.5f * Time.deltaTime);
        }
    }

    public void LoadSetting()
    {
        SettingCanvas.SetActive(true);
    }
    public void CloseSetting()
    {
        SettingCanvas.SetActive(false);
    }

    public void LoadQuestion()
    {
        CharlieTime = true;
        Define.Player.GetComponent<AgentMovement>().ResetVelcity();
        iamgeOne.sprite = sprite[curCount++];
        imageTwo.sprite = sprite[curCount++];
        imageThree.sprite = sprite[curCount++];
        if (curCount >= maxCount)
        {
            //ShuffleList(sprite);
            curCount = 0;
        }
        QuestionCanvas.SetActive(true);
        SoundManager.Instance.PlayBGMSound(questionClip);
    }

    public void CloseQuestion()
    {
        QuestionCanvas.SetActive(false);
    }

    public void AnswerYes()
    {
        int random = Random.Range(0, 4);
        Debug.Log("Yes");
        Debug.Log(random);
        pencil.rotation = Quaternion.Euler(0, 0, -90);
        angle = Mathf.Atan2(YesTrs[random].transform.position.y - pencil.transform.position.y, YesTrs[random].transform.position.x - pencil.transform.position.x) * Mathf.Rad2Deg;
    }

    public void AnswerNo()
    {
        int random = Random.Range(0, 4);
        Debug.Log("No");
        Debug.Log(random);
        pencil.rotation = Quaternion.Euler(0, 0, -90);
        angle = Mathf.Atan2(NoTrs[random].transform.position.y - pencil.transform.position.y, NoTrs[random].transform.position.x - pencil.transform.position.x) * Mathf.Rad2Deg;
    }

    public void ClickOne()
    {
        int cur = curCount - 3;
        Debug.Log(1);
        if (cur % 2 != 0)
            AnswerYes();
        else
            AnswerNo();
    }

    public void ClickTwo()
    {
        int cur = curCount - 2;
        Debug.Log(2);
        if (cur % 2 != 0)
            AnswerYes();
        else
            AnswerNo();
    }

    public void ClickThree()
    {
        int cur = curCount - 1;
        Debug.Log(3);
        if (cur % 2 != 0)
            AnswerYes();
        else
            AnswerNo();
    }

    public void LoadAnswer()
    {
        CloseQuestion();
        AnswerCanvas.SetActive(true);
        StartCoroutine(AnswerEndTimer());
    }

    IEnumerator AnswerEndTimer()
    {
        yield return new WaitForSeconds(8f);
        CloseAnswer();
    }

    public void CloseAnswer()
    {
        AnswerCanvas.SetActive(false);
        player.ChaseFunc();
        CharlieTime = false;
        SoundManager.Instance.PlayBGMSound(chaseClip);
    }


    //public void ShuffleList<T>(List<T> list)
    //{
    //    int random1;
    //    int random2;

    //    T tmp;

    //    for (int index = 0; index < list.Count; ++index)
    //    {
    //        random1 = UnityEngine.Random.Range(0, list.Count);
    //        random2 = UnityEngine.Random.Range(0, list.Count);

    //        tmp = list[random1];
    //        list[random1] = list[random2];
    //        list[random2] = tmp;
    //    }
    //}
}
