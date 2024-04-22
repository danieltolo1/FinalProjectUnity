using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimacionesUI : MonoBehaviour
{

    [SerializeField] private GameObject inicioLogo;



    private void Start()
    {

        BajarAlpha(inicioLogo, 0f, 0f, 0f);
        SubirAlpha(inicioLogo, 1f, 1f, 35f);
        BajarAlpha(inicioLogo, 0f, 1f, 41f);


    }

    private void BajarAlpha(GameObject name, float state1, float animationTime, float StartAnimation)
    {
        LeanTween.alpha(name.GetComponent<RectTransform>(), state1, animationTime).setDelay(StartAnimation);
    }

    private void SubirAlpha(GameObject name, float stateF, float animationTim, float StrAnimation)
    {
        LeanTween.alpha(name.GetComponent<RectTransform>(), stateF, animationTim).setDelay(StrAnimation);
    }
}
