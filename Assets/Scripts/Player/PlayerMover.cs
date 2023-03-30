using UnityEngine;
using Zenject;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _speed = 1f;

    private Rigidbody _rigidbody;
    private IInputService _playerInputs;
    private float _inputX;
    private float _inputZ;

    [Inject] 
    private void Construct(IInputService playerInputs)
    {
        _playerInputs = playerInputs;
    }

    private void Awake()
    {
        _playerInputs.OnPlayerMovedXZ += Mover;
        _cameraTransform = _cameraTransform.GetComponent<Transform>();
        _rigidbody = GetComponentInChildren<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(
            (transform.TransformDirection(_cameraTransform.forward) * _inputZ * _speed)
            + (transform.TransformDirection(_cameraTransform.right) * _inputX * _speed));
    }

    private void Mover(float x,float z)
    {
        _inputX = x;
        _inputZ = z;
    }

    private void OnDisable()
    {
        _playerInputs.OnPlayerMovedXZ -= Mover;
    }
}
