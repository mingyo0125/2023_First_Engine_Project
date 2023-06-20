using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    private void LateUpdate()
    {
        _camera.transform.Rotate(0, transform.position.y + -0.05f, 0);
    }
}
