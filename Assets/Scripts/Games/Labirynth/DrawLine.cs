using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public bool CanDraw;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _startTransform;
    [SerializeField] private float minDistance = 0.1f;
    [SerializeField] private List<Material> _materials;
    private LineRenderer _line;
    private Vector3 _previousPos;

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
        _previousPos = transform.position;
    }

   

    public void Draw()
    {
        if(CanDraw)
        {
            Vector3 currentPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 0;
            if (Vector3.Distance(currentPosition, _previousPos) > minDistance)
            {
                _line.positionCount++;

                _line.SetPosition(_line.positionCount - 1, currentPosition);
                _previousPos = currentPosition;
            }
        }
      
    }
    public void Clean()
    {
        _line.positionCount = 1;
        _line.SetPosition(0, _startTransform.position);
    }
}
