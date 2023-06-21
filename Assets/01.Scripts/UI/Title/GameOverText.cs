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

    private void Update()
    {
        if(_score == 0)
        {
            _score = InputManager.Instance.Score;
            _scoreText.SetText(_score.ToString());
            _score = 0;
        }
    }
}
