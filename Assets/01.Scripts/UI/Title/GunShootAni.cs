using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootAni : MonoBehaviour
{
    [SerializeField]
    private float waitTime;
    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(waitTime);
        _animator.SetTrigger("StartTrigger");
    }
}
