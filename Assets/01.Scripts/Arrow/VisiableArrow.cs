using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class VisiableArrow : MonoBehaviour
{
    [SerializeField]
    private int id;

    KeyCode keyCode;

    private readonly KeyCode[] arr = { KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.UpArrow };

    Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        if (ArrowSpawner.Instance.RoundCount == 5) //º¸½º
        {
            StartCoroutine(ChangeArrow());
        }
        else
        {
            _image.color = Color.white;
        }
    }

    public void SetArrowRotation()
    {
        _image.enabled = true;

        float value = 0;

        keyCode = ArrowSpawner.Instance._arrowList[id].keyCode;

        switch (keyCode)
        {
            case KeyCode.LeftArrow:
                value = 180;
                break;
            case KeyCode.RightArrow:
                value = 0;
                break;
            case KeyCode.UpArrow:
                value = 90;
                break;
            case KeyCode.DownArrow:
                value = -90;
                break;
        }

        Vector3 rotateVec = _image.rectTransform.eulerAngles;
        rotateVec.z = value;
        _image.rectTransform.eulerAngles = rotateVec;
    }

    private IEnumerator ChangeArrow()
    {
        KeyCode randKey;

        _image.color = Color.red;

        while (true)
        {
            randKey = arr[Random.Range(0, 4)];
            keyCode = keyCode == randKey ? arr[Random.Range(0, 4)] : randKey;
            SetArrowRotation();
            yield return new WaitForSeconds(2f);
        }

    }
}
