using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetResolution : MonoBehaviour
{
    [SerializeField]
    CanvasScaler thisCanvas;

    void Awake()
    {
        float fixedAspectRatio = 9f / 16f;
        float currentAspectRatio = (float)Screen.width / (float)Screen.height;
        if (currentAspectRatio > fixedAspectRatio) thisCanvas.matchWidthOrHeight = 1;
        else if (currentAspectRatio < fixedAspectRatio) thisCanvas.matchWidthOrHeight = 0;
    }

}
