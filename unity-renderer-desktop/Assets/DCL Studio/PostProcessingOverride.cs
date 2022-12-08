using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using DG.Tweening;
public class PostProcessingOverride : MonoBehaviour
{

    [SerializeField]
    Image ppToggleBackground;

    [SerializeField]
    Toggle ppToggle;

    [SerializeField]
    GameObject ppGameObject;

    [SerializeField]
    Volume ppVolume;

    [SerializeField]
    Slider saturationSlider, contrastSlider, lenDistortionSlider;



    ColorAdjustments colorAdjustment;

    LensDistortion lensDistortion;

  


    public void Start()
    {
        ppVolume.profile.TryGet<ColorAdjustments>(out colorAdjustment);
        ppVolume.profile.TryGet<LensDistortion>(out lensDistortion);
    }

    public void TogglePostProcessing()
    {

        ppGameObject.SetActive(ppToggle.isOn);
        if (ppToggle.isOn)
        {
            ppToggleBackground.color = Color.red;
        }
        else
        {
            ppToggleBackground.color = Color.white;
        }  
    }



    public void SetSaturation()
    {
        colorAdjustment.saturation.value = saturationSlider.value;
    }


    public void ResetSaturation()
    {
        colorAdjustment.saturation.value = 0;
        saturationSlider.value = 0;
    }

    public float GetSaturation()
    {
        return saturationSlider.value;
    }





    public void SetContrast()
    {
        colorAdjustment.contrast.value = contrastSlider.value;
    }


    public void ResetContrast()
    {
        colorAdjustment.contrast.value = 0;
        contrastSlider.value = 0;
    }

    public float GetContrast()
    {
        return contrastSlider.value;
    }





    public void SetLensDistortion()
    {
        lensDistortion.intensity.value = lenDistortionSlider.value;
    }

    public void ResetLensDistortion()
    {
        lensDistortion.intensity.value = 0;
        lenDistortionSlider.value = 0;
    }

    public float GetLensDistortion()
    {
        return lenDistortionSlider.value;
    }



    public void SetAllValues(Presets presets)
    {
        Debug.Log(presets.saturation);

        DOTween.To(x => {
            saturationSlider.value = x;
        }, saturationSlider.value, presets.saturation, presets.time);


        DOTween.To(x => {
            contrastSlider.value = x;
        }, contrastSlider.value, presets.contrast, presets.time);

        DOTween.To(x => {
            lenDistortionSlider.value = x;
        }, lenDistortionSlider.value, presets.lensDist, presets.time);


   

    }
}
