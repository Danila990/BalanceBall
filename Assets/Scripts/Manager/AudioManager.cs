using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("AudioSource")]
    [SerializeField] private AudioSource _mainAUS;
    [SerializeField] private AudioSource _backAUS;

    [Header("Sound")]
    [SerializeField] private AudioClip _backSound;
    [SerializeField] private AudioClip _windSound;
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip _water;

    public bool _isSoundOff { get; private set; } = false;

    private void Awake()
    {
        _mainAUS = _mainAUS.GetComponent<AudioSource>();
        _backAUS = _backAUS.GetComponent<AudioSource>();
        PlayBackSound();
    }

    private void PlayBackSound()
    {
        _backAUS.clip = _backSound;
        _backAUS.Play();
    }

    public void PlayPlayerWaterSound()
    {
        _mainAUS.clip = _water;
        _mainAUS.Play();
    }

    public void PlayClickSound()
    {
        _mainAUS.clip = _clickSound;
        _mainAUS.Play();
    }
    
    public void SoundOFF()
    {
        _mainAUS.mute = true;
        _backAUS.mute = true;
        _isSoundOff = true;
    }
    public void SoundON()
    {
        _mainAUS.mute = false;
        _backAUS.mute = false;
        _isSoundOff = false;
    }
}
