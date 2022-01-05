using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera _raycastCam;
    [SerializeField] private float _left, _right, _up, _down;

    Vector3 cameraCurrentPos;
    private Vector3 _startPoint;
    private Vector3 _origin;

    [SerializeField] private float _cameraSpeed = 20f;

    public static bool IsDragging = false;

    private void Start()
    {
        cameraCurrentPos = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPoint = GetMousePos();
            _origin = transform.position;
        }

        if (Input.GetMouseButton(0) && !IsDragging)
        {
            MoveCamera();
        }
    }

    private Vector3 GetMousePos()
    {
        Vector3 mousePos = _raycastCam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    void MoveCamera()
    {
        Vector3 delta = GetMousePos() - _startPoint;
        cameraCurrentPos = Vector3.Lerp(cameraCurrentPos, _origin - delta, _cameraSpeed * Time.deltaTime);
        
        cameraCurrentPos.x = Mathf.Clamp(cameraCurrentPos.x, _left, _right);
        cameraCurrentPos.y = Mathf.Clamp(cameraCurrentPos.y, _down, _up);

        transform.position = cameraCurrentPos;

    }
}
