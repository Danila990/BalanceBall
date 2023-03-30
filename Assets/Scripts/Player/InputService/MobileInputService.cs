using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class MobileInputService : MonoBehaviour, IInputService
{
    [SerializeField] private GameObject _arrowCanvas;

    private float _inputX;
    private float _inputZ;

    public event UnityAction<float,float> OnPlayerMovedXZ;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
            _arrowCanvas.SetActive(true);
        else _arrowCanvas.SetActive(false);
        SceneManager.sceneLoaded += LoadSceneEvent;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= LoadSceneEvent;
    }

    private void LoadSceneEvent(Scene scene, LoadSceneMode loadSceneMode)
    {
        if(scene.buildIndex != 0)
            _arrowCanvas.SetActive(true);
        else _arrowCanvas.SetActive(false);
    }

    public void Update()
    {
        if (_inputX != 0 || _inputZ != 0)
            OnPlayerMovedXZ?.Invoke(_inputX, _inputZ);
    }

    public void LeftRightClickButton(float x)
    {
        _inputX = x;
    }

    public void DownUpClickButton(float z)
    {
        _inputZ = z;
    }

    public void ResetInputX()
    {
        _inputX = 0;
        OnPlayerMovedXZ?.Invoke(0, _inputZ);
    }

    public void ResetInputZ()
    {
        _inputZ = 0;
        OnPlayerMovedXZ?.Invoke(_inputX, 0);
    }
}
