using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;
    private int score;


    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        InitText();
    }

    private void InitText()
    {
        score = PlayerPrefs.GetInt("Score");
        _textMeshPro.SetText($"Score  {score}");
    }
}
