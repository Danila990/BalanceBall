using UnityEngine;
using UnityEngine.Events;

public class PcInputService : MonoBehaviour, IInputService
{
    public event UnityAction<float, float> OnPlayerMovedXZ;

    public void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        if (inputX >= 0.1f || inputX <= -0.1f || inputZ >= 0.1f || inputZ <= -0.1f)
            OnPlayerMovedXZ?.Invoke(inputX, inputZ);
        else OnPlayerMovedXZ?.Invoke(0, 0);
    }
}
