using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject SettingGrp;

    void Awake()
    {
        SettingGrp.SetActive(false);
    }

    public void ActiveSetting(bool value)
    {
        SettingGrp.SetActive(value);
    }

    [System.Obsolete]
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SettingGrp.SetActive(!SettingGrp.active);
            if(SettingGrp.active == true)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
    }
}
