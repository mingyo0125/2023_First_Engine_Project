using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : PoolableMono
{
    public KeyCode keyCode;

    private KeyCode[] arr = { KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.UpArrow};

    public override void Init()
    {
        keyCode = arr[UnityEngine.Random.Range(0, 4)];

        SetArrowRotation();

        if(ArrowSpawner.Instance.RoundCount % 5 == 0)
        {
            StartCoroutine(ChangeArrow());
        }
    }

    private void SetArrowRotation()
    {
        switch (keyCode)
        {
            case KeyCode.LeftArrow:
                transform.rotation = Quaternion.Euler(0f, 0f, 90);
                break;
            case KeyCode.RightArrow:
                transform.rotation = Quaternion.Euler(0f, 0f, -90);
                break;
            case KeyCode.UpArrow:
                transform.rotation = Quaternion.identity;
                break;
            case KeyCode.DownArrow:
                transform.rotation = Quaternion.Euler(0f, 0f, 180);
                break;
        }
    }

    private IEnumerator ChangeArrow()
    {
        KeyCode randKey;
        while(true)
        {
            randKey = arr[UnityEngine.Random.Range(0, 4)];
            keyCode = keyCode == randKey ? arr[UnityEngine.Random.Range(0, 4)] : randKey;
            SetArrowRotation();
            yield return new WaitForSeconds(1f);
        }
    }
}
