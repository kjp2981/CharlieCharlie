using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Define;

public class ButtonManager : MonoBehaviour
{
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
}
