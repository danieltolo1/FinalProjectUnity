using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.ComponentModel;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using System;

public class AnimationPanelMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject panelGroup;
    [SerializeField] private GameObject buttonText1;
    [SerializeField] private GameObject buttonText2;
    [SerializeField] private GameObject buttonText3;
    [SerializeField] private GameObject buttonText4;




    private void Start()
    {
        BajarAlpha(panelGroup, 0f, 0f, 0f);
        SubirAlpha(panelGroup, 0.85f, 3f, 46.5f);
        ChangeAlphaText(buttonText1, 0f, 0f, 0f, 0f);
        ChangeAlphaText(buttonText1, 0f, 1f, 3f, 47f);
        ChangeAlphaText(buttonText2, 0f, 0f, 0f, 0f);
        ChangeAlphaText(buttonText2, 0f, 1f, 3f, 47f);
        ChangeAlphaText(buttonText3, 0f, 0f, 0f, 0f);
        ChangeAlphaText(buttonText3, 0f, 1f, 3f, 47f);
        ChangeAlphaText(buttonText4, 0f, 0f, 0f, 0f);
        ChangeAlphaText(buttonText4, 0f, 1f, 3f, 47f);

    }






    private void BajarAlpha(GameObject name, float state1, float animationTime, float StartAnimation)
    {
        LeanTween.alpha(name.GetComponent<RectTransform>(), state1, animationTime).setDelay(StartAnimation);


    }

    private void SubirAlpha(GameObject name, float stateF, float animationTim, float StrAnimation)
    {
        LeanTween.alpha(name.GetComponent<RectTransform>(), stateF, animationTim).setDelay(StrAnimation);
        //name.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    private void ChangeAlphaText(GameObject text, float data1, float estat, float StAnimation, float delayTime)
    {

        LeanTween.value(text, data1, estat, StAnimation).setOnUpdate(UpdateTextAlpha).setDelay(delayTime);
    }

    private void UpdateTextAlpha(float alpha)
    {
        Color color = buttonText1.GetComponent<TextMeshProUGUI>().color;
        color.a = alpha;
        buttonText1.GetComponent<TextMeshProUGUI>().color = color;
        Color color2 = buttonText2.GetComponent<TextMeshProUGUI>().color;
        color2.a = alpha;
        buttonText2.GetComponent<TextMeshProUGUI>().color = color;
        Color color3 = buttonText3.GetComponent<TextMeshProUGUI>().color;
        color3.a = alpha;
        buttonText3.GetComponent<TextMeshProUGUI>().color = color;
        Color color4 = buttonText4.GetComponent<TextMeshProUGUI>().color;
        color4.a = alpha;
        buttonText4.GetComponent<TextMeshProUGUI>().color = color;
    }


}
