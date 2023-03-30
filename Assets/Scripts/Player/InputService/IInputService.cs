using UnityEngine.Events;

public interface IInputService
{
    public event UnityAction<float,float> OnPlayerMovedXZ;

    void Update();
}
