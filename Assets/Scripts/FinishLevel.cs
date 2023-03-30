using UnityEngine;
using Zenject;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private GameObject _finishPanel;

    private GameManager _gameManager;

    [Inject] 
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        _gameManager.PauseGame();
        _gameManager.OnLevelComplite.Invoke();
    }
}
