using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : PoolableMono
{
    public KeyCode keyCode;

    SpriteRenderer _spriteRenderer;

    private readonly KeyCode[] arr = { KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.UpArrow};

    public override void Init()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        keyCode = arr[UnityEngine.Random.Range(0, 4)];

        SetArrowRotation();

        if(ArrowSpawner.Instance.RoundCount == 5) //����
        {
            //StartCoroutine(ChangeArrow());
        }
        else
        {
        }
            _spriteRenderer.color = Color.white;
    }

    private void SetArrowRotation()
    {
        switch (keyCode)
        {
            case KeyCode.LeftArrow:
                transform.rotation = Quaternion.Euler(0f, 90f, 180);
                break;
            case KeyCode.RightArrow:
                transform.rotation = Quaternion.Euler(0f, 90f, 0);
                break;
            case KeyCode.UpArrow:
                transform.rotation = Quaternion.Euler(0f, 90f, 90);
                break;
            case KeyCode.DownArrow:
                transform.rotation = Quaternion.Euler(0f, 90f, -90);
                break;
        }
    }

    private IEnumerator ChangeArrow()
    {
        KeyCode randKey;

        _spriteRenderer.color = Color.red;

        while (true)
        {
            randKey = arr[UnityEngine.Random.Range(0, 4)];
            keyCode = keyCode == randKey ? arr[UnityEngine.Random.Range(0, 4)] : randKey;
            SetArrowRotation();
            yield return new WaitForSeconds(2f);
        }

    }
}
