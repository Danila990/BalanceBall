using UnityEngine;
using Zenject;

public class InputServiceInstaller : MonoInstaller
{
    [SerializeField] private bool _isMobile;
    [SerializeField] private PcInputService _pcInputServicePrefab;
    [SerializeField] private MobileInputService _mobileInputServicePrefab;

    public override void InstallBindings()
    {
        if (_isMobile)
            Container.Bind<IInputService>().To<MobileInputService>().FromComponentInNewPrefab(_mobileInputServicePrefab).AsSingle().NonLazy();
        else Container.Bind<IInputService>().To<PcInputService>().FromComponentInNewPrefab(_pcInputServicePrefab).AsSingle().NonLazy();
    }
}