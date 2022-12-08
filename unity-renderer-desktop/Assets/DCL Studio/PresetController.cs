using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PresetController : MonoBehaviour
{
    [SerializeField]
    PostProcessingOverride postProcessingOverride;
    BlackFader blackFader;
    
    
    
    [SerializeField]
    Presets presetOne = new Presets(), presetsTwo = new Presets(), presetsThree = new Presets(), presetsFour = new Presets(), presetsFive = new Presets(), presetsSix = new Presets();
    Presets[] presetArray;


    [SerializeField]
    TMP_InputField presetOneTimeInput, presetTwoTimeInput, presetThreeTimeInput, presetFourTimeInput, presetFiveTimeInput, presetSixTimeInput;
    TMP_InputField[] presetTimeInputArray;

    [SerializeField]
    GameObject presetOneButtonGO, presetTwoButtonGO, presetThreeButtonGO, presetFourButtonGO, presetFiveButtonGO, presetSixButtonGO;
    GameObject[] presetButtonGOArray;
    
    private void Start()
    {
       
        presetArray = new Presets[] { presetOne, presetsTwo, presetsThree, presetsFour, presetsFive, presetsSix};
        presetTimeInputArray = new TMP_InputField[] { presetOneTimeInput, presetTwoTimeInput, presetThreeTimeInput, presetFourTimeInput, presetFiveTimeInput, presetSixTimeInput };
        presetButtonGOArray = new GameObject[] {presetOneButtonGO, presetTwoButtonGO, presetThreeButtonGO, presetFourButtonGO, presetFiveButtonGO, presetSixButtonGO };

        postProcessingOverride = gameObject.GetComponent<PostProcessingOverride>();
        blackFader = gameObject.GetComponent<BlackFader>();
        presetOneTimeInput.text = 15.ToString();
        presetOne.time = 15;
    }

    public void SetPreset(int index)
    {
        presetArray[index].saturation = postProcessingOverride.GetSaturation();
        presetArray[index].contrast = postProcessingOverride.GetContrast();
        presetArray[index].lensDist = postProcessingOverride.GetLensDistortion();
        presetArray[index].blackFade = blackFader.GetBlackOpacity();
    }

    public void SetPresetTime(int index)
    {
        presetArray[index].time = float.Parse(presetTimeInputArray[index].text);
    }

    public void RenPreset(int index)
    {
        postProcessingOverride.SetAllValues(presetArray[index]);
        blackFader.SetBlackOpacity(presetArray[index]);
        presetButtonGOArray[index].GetComponent<Image>().color = Color.green;
        StartCoroutine(ResetButtonColor(presetButtonGOArray[index], presetArray[index].time));
    }


    IEnumerator ResetButtonColor(GameObject buttonGO, float time)
    {
        yield return new WaitForSeconds(time);
        buttonGO.GetComponent<Image>().color = Color.white;

    }
}


public class Presets
{
    [SerializeField]
    public float saturation = 0;
    [SerializeField]
    public float contrast = 0;
    [SerializeField]
    public float lensDist = 0;
    [SerializeField]
    public float blackFade = 0;
    [SerializeField]
    public float time = 15;
}