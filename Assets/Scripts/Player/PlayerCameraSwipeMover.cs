using System.Collections;
using UnityEngine;

public class PlayerCameraSwipeMover : MonoBehaviour
{
    [SerializeField] private int _currentPosition = 0;
    [SerializeField] private Transform _targetCharacterBody;
    [SerializeField] private Vector2 _cameraOffset;
    [SerializeField] private float _cameraRotateSpeed = 10f;
    [SerializeField] private float _cameraOffsetSpeed = 10f;

    private Vector3[] _cameraOffsetArray;
    private float[] _cameraRotateYArray;
    private InputSwipe _swipeCamera;
    private Transform _camera;

    private void Start()
    {
        _swipeCamera = GetComponent<InputSwipe>();
        _camera = GetComponent<Transform>();
        SetCameraParameters();

        _camera.position = _targetCharacterBody.position + _cameraOffsetArray[_currentPosition];
        _swipeCamera.OnSwipeLeft += CameraMoveLeft;
        _swipeCamera.OnSwipeRight += CameraMoveRight;
    }

    private void OnDisable()
    {
        _swipeCamera.OnSwipeLeft -= CameraMoveLeft;
        _swipeCamera.OnSwipeRight -= CameraMoveRight;
    }

    private void SetCameraParameters()
    {
        _cameraOffsetArray = new Vector3[4];
        _cameraOffsetArray[0] = new Vector3(-_cameraOffset.x, _cameraOffset.y, 0);
        _cameraOffsetArray[1] = new Vector3(0, _cameraOffset.y, -_cameraOffset.x);
        _cameraOffsetArray[2] = new Vector3(_cameraOffset.x, _cameraOffset.y, 0);
        _cameraOffsetArray[3] = new Vector3(0, _cameraOffset.y, _cameraOffset.x);

        _cameraRotateYArray = new float[4];
        _cameraRotateYArray[0] = 90f;
        _cameraRotateYArray[1] = 0f;
        _cameraRotateYArray[2] = -90f;
        _cameraRotateYArray[3] = -180f;
    }

    private void Update()
    {
        _camera.position =
            Vector3.Lerp(gameObject.transform.position, _targetCharacterBody.position + _cameraOffsetArray[_currentPosition], Time.deltaTime * _cameraOffsetSpeed); 

        if(_camera.rotation.y != _cameraRotateYArray[_currentPosition])
            _camera.rotation =
                Quaternion.Lerp(gameObject.transform.rotation, Quaternion.Euler(30, _cameraRotateYArray[_currentPosition], 0), Time.deltaTime * _cameraRotateSpeed);
    }

    private void CameraMoveLeft()
    {
        _currentPosition -= 1;
        if (_currentPosition <= -1)
            _currentPosition = _cameraOffsetArray.Length - 1;
    }

    private void CameraMoveRight()
    {
        _currentPosition += 1;
        if (_currentPosition >= _cameraOffsetArray.Length)
            _currentPosition = 0;
    }
}
