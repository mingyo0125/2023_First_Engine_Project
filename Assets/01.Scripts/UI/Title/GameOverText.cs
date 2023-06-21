using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _bestText;
    private TextMeshProUGUI _scoreText;

    private int _score = 0;

    private void Awake()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void InitText()
    {
        _score = InputManager.Instance.bestScore;
        _scoreText.SetText(_score.ToString());
        InputManager.Instance.bestScore = 0;
    }
}
