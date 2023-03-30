using UnityEngine;
using Zenject;

public class ClickSound : MonoBehaviour
{
    private AudioManager _audioManager;

    [Inject]
    private void Constrict(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }
    public void PlayClickSound()
    {
        _audioManager.PlayClickSound();
    }
}
