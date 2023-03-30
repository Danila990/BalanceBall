using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SoundOFFON : MonoBehaviour
{
    [SerializeField] private Sprite _onScprite;
    [SerializeField] private Sprite _offSsprite;

    private Image _buttonImage;
    private AudioManager _audioManager;

    [Inject]
    private void Constrict(AudioManager audioManager)
    {
        _audioManager = audioManager;
        _buttonImage = GetComponent<Image>();
        SetStartImage();
    }

    private void SetStartImage()
    {
        if (_audioManager._isSoundOff)
            _buttonImage.sprite = _offSsprite; 
        else _buttonImage.sprite = _onScprite;
    }

    public void SoundONOFF()
    {
        if (_buttonImage.sprite == _onScprite)
        {
            _audioManager.SoundOFF();
            _buttonImage.sprite = _offSsprite;
        }
        else
        {
            _audioManager.SoundON();
            _buttonImage.sprite = _onScprite;
        }
    }
}
