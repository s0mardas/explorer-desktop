using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackFader : MonoBehaviour
{

    [SerializeField]
    Slider fadeBlackSlider;

    [SerializeField]
    Image blackImage;

    [SerializeField]
    Toggle blackToggle;

    [SerializeField]
    GameObject blackGO;

    [SerializeField]
    Image blackToggleBackground;
    Color color = new Color(0,0,0,0);

    public void ChangeBlackOpacity()
    {
        color.a = fadeBlackSlider.value;
        blackImage.color = color;
    }

    public float GetBlackOpacity()
    {
        return blackImage.color.a;
    }

    public void SetBlackOpacity(Presets presets)
    {
       
        DOTween.To(x => {
            fadeBlackSlider.value = x;
        }, fadeBlackSlider.value, presets.blackFade, presets.time);

    }

    public void ChangeBlackToggle()
    {
        blackGO.SetActive(blackToggle.isOn);
        if (blackToggle.isOn)
        {
            blackToggleBackground.color = Color.red;
        }
        else
        {
            blackToggleBackground.color = Color.white;

        }
    }


}
