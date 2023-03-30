using UnityEngine;
using Zenject;

public class AudionManagerInstaller : MonoInstaller
{
    [SerializeField] private AudioManager _audioManager;
    public override void InstallBindings()
    {
        Container.Bind<AudioManager>().FromComponentInNewPrefab(_audioManager).AsSingle().NonLazy(); ;
    }
}