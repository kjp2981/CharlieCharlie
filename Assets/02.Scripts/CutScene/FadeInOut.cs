using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeInOut : MonoBehaviour
{
    public Image panel;

    public void FadeIn()
    {
        if(panel.color.a > 0)
        {
            panel.color = new Color(1, 1, 1, 0);
        }

        panel.DOFade(1, .3f);
    }

    public void FadeOut()
    {
        if (panel.color.a < 255f)
        {
            panel.color = Color.black;
        }

        panel.DOFade(0, .3f);
    }
}
