using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class OpenLoadLevels : MonoBehaviour
{
    private GameManager _gameManager;

    [Inject]
    private void Constrict(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    private void Awake()
    {
        if (_gameManager._levelsComplete == 1)
        {
            transform.GetChild(0).GetComponent<Button>().interactable = true;
            return;
        }
            
        for (int i = 0; i < _gameManager._levelsComplete; i++)
        {
            transform.GetChild(i).GetComponent<Button>().interactable = true;
        }
    }
}
