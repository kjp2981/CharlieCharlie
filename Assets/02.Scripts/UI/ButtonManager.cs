using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    public GameObject SettingCanvas;
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadSetting()
    {
        SettingCanvas.SetActive(true);
    }
    public void CloseSetting()
    {
        SettingCanvas.SetActive(false);
    }
}
