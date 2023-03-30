using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GUICanvas : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _selectLevelPanel;
    [SerializeField] private GameObject _levelComplitePanel;

    private GameManager _gameManager;
    private AudioManager _audioManager;

    [Inject]
    private void Construct(GameManager gameManager,AudioManager audioManager)
    {
        _gameManager = gameManager;
        _audioManager = audioManager;
        _gameManager.OnLevelComplite += OpenLevelCompliteMenu;
    }

    private void OnDisable()
    {
        _gameManager.OnLevelComplite -= OpenLevelCompliteMenu;
    }

    private void OpenLevelCompliteMenu()
    {
        _menuPanel.SetActive(false);
        _selectLevelPanel.SetActive(false);
        _levelComplitePanel.SetActive(true);
        _gameManager.PauseGame();
    }

    public void OpenMenu()
    {
        _menuPanel.SetActive(true);
        _audioManager.PlayClickSound();
        _gameManager.PauseGame();
    }

    public void LoadMainMenu()
    {
        _audioManager.PlayClickSound();
        _gameManager.RePauseeGame();
        _gameManager.LoadMainMenu();
    }

    public void OpenSelectLevelPanel()
    {
        _audioManager.PlayClickSound();
        _menuPanel.SetActive(false);
        _selectLevelPanel.SetActive(true);
    }

    public void CloseMenu()
    {
        _menuPanel.SetActive(false);
        _audioManager.PlayClickSound();
        _gameManager.RePauseeGame();
    }

    public void LoadLevel(int level)
    {
        _audioManager.PlayClickSound();
        _gameManager.RePauseeGame();
        _gameManager.LoadLevel(level);
    }

    public void CloseSelectLevelPanel() 
    {
        _audioManager.PlayClickSound();
        _selectLevelPanel.SetActive(false);
        _menuPanel.SetActive(true);
    }

    public void LoadNextLevel()
    {
        _audioManager.PlayClickSound();
        _gameManager.RePauseeGame();
        _gameManager.LoadNextLevel();
    }
}
