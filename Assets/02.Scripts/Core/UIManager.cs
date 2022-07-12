using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Define;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;

    public Text questionText;
    public Text charlieChaseText;

    private Player player;

    void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple GameManager is running");
        Instance = this;
    }

    private void Start()
    {
        player = Define.Player.GetComponent<Player>();
    }

    private void Update()
    {
        if(player.chaseTimer<=0f&&player.questionTimer>0.0f)
        {
            questionText.gameObject.SetActive(true);
            charlieChaseText.gameObject.SetActive(false);
            questionText.text = "질문 시간: " + player.questionTimer;
        }
        else
        {
            questionText.gameObject.SetActive(false);
            charlieChaseText.gameObject.SetActive(true);
            charlieChaseText.text = "추격 시간: " + player.chaseTimer;
        }
    }
}
