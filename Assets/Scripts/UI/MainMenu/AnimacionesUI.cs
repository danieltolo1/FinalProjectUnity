using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimacionesUI : MonoBehaviour
{
    [SerializeField] private GameObject logo;

    private void Start()
    {
        LeanTween.moveX(logo.GetComponent<RectTransform>(), 0, 2.5f).setDelay(35f);
    }
}
