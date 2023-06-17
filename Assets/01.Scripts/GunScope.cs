using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScope : MonoBehaviour
{
    MeshRenderer gun;
    Animator _animator;

    [SerializeField]
    GameObject _scopeImage;

    private readonly int hashScope = Animator.StringToHash("IsScope");
    private readonly int hashEnd = Animator.StringToHash("IsEnd");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        gun = GetComponent<MeshRenderer>();

        ScopeOn();
    }

    public void ScopeOff()
    {
        _scopeImage.gameObject.SetActive(false);
        gun.enabled = true;
        _animator.SetBool(hashScope, false);
    }

    public void ScopeOn()
    {
        _animator.SetBool(hashEnd, false);
        _animator.SetBool(hashScope, true);
    }

    public void ScopeOnAniEnd()
    {
        gun.enabled = false;
        _scopeImage.gameObject.SetActive(true);
    }

    public void ScopeOffAniEnd()
    {
        _animator.SetBool(hashEnd, true);
    }

}
