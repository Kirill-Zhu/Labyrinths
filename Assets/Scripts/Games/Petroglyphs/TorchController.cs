using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _mask;
    private Vector3 _mousePos;
    private void Update()
    {
       
        _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = 0;
        transform.position = _mousePos;

        if (Input.touchCount != 0)
        {
            _mousePos = Input.touches[0].position;
        }
    }
    private void OnEnable()
    {
        transform.position = new Vector3(5, -3, 0);
    }
}
