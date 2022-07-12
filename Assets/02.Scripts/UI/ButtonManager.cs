using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Define;

public class ButtonManager : MonoBehaviour
{
    public List<Sprite> sprite = new List<Sprite>();

    public Image iamgeOne;
    public Image imageTwo;
    public Image imageThree;

    public int curCount = 0;
    public int maxCount = 12;

    public static ButtonManager Instance = null;

    public GameObject SettingCanvas;
    public GameObject QuestionCanvas;
    public GameObject AnswerCanvas;

    private Player player;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple GameManager is running");
        Instance = this;
    }

    private void Start()
    {
        player = Define.Player.GetComponent<Player>();
        ShuffleList(sprite);
    }

    public void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
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
        iamgeOne.sprite = sprite[curCount++];
        imageTwo.sprite = sprite[curCount++];
        imageThree.sprite = sprite[curCount++];
        if (curCount >= maxCount)
        {
            ShuffleList(sprite);
            curCount = 0;
        }
        QuestionCanvas.SetActive(true);
    }

    public void CloseQuestion()
    {
        QuestionCanvas.SetActive(false);
    }

    public void LoadAnswer()
    {
        CloseQuestion();
        AnswerCanvas.SetActive(true);
        StartCoroutine(AnswerEndTimer());
    }

    IEnumerator AnswerEndTimer()
    {
        yield return new WaitForSeconds(5f);
        CloseAnswer();
    }

    public void CloseAnswer()
    {
        AnswerCanvas.SetActive(false);
        player.ChaseFunc();
    }


    public void ShuffleList<T>(List<T> list)
    {
        int random1;
        int random2;

        T tmp;

        for (int index = 0; index < list.Count; ++index)
        {
            random1 = UnityEngine.Random.Range(0, list.Count);
            random2 = UnityEngine.Random.Range(0, list.Count);

            tmp = list[random1];
            list[random1] = list[random2];
            list[random2] = tmp;
        }
    }
}
