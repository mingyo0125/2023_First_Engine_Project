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

    private bool isBoss = false;

    Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        if (isBoss)
        {
            StartCoroutine(ChangeArrow());
            isBoss = false;
            return;
        }
        if (ArrowSpawner.Instance.RoundCount == 5) //º¸½º
        {
            isBoss = true;
            //ArrowSpawner.Instance.RoundCount = 1;
            //_image.color = Color.white;
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
        Debug.Log(name);
        _image.color = Color.red;

        while (true)
        {
            KeyCode randKey = arr[Random.Range(0, 4)];
            while (randKey != keyCode) 
            {
                randKey = arr[Random.Range(0, 4)];
            }
            keyCode = randKey;
            SetArrowRotation();
            yield return new WaitForSeconds(2f);
        }

    }
}
