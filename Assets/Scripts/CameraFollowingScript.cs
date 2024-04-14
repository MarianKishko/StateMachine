using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowingScript : MonoBehaviour
{
    [SerializeField] private Vector3 _distanceBetweenMainCameraAndPlayer;
    [SerializeField] private Transform _pointToLookAt;

    private Camera _mainCamera;
    private Vector3 _offset;
    private float _cameraRotationSpeed = 50;

    void Start()
    {
        _mainCamera = Camera.main.GetComponent<Camera>();
        _offset = _distanceBetweenMainCameraAndPlayer;
    }

    void Update()
    {
        _offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * _cameraRotationSpeed, Vector3.up) * _offset;

        _mainCamera.transform.position = transform.position + _offset;

        _mainCamera.transform.LookAt(_pointToLookAt);
    }
}
