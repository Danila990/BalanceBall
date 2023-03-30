using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _currentScene;

    public Action OnLevelComplite;
    public int _levelsComplete { get; private set; }

    private void Awake()
    {
        _levelsComplete = PlayerPrefs.GetInt("LevelsComplete");
        if(_levelsComplete ==0)
            _levelsComplete++;
        PlayerPrefs.SetInt("LevelsComplete", _levelsComplete);

        _currentScene = SceneManager.GetActiveScene().buildIndex;
        Application.targetFrameRate = -1;
        SceneManager.sceneLoaded += LoadSceneEvent;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= LoadSceneEvent;
    }

    private void LoadSceneEvent(Scene scene, LoadSceneMode loadSceneMode)
    {
        _currentScene = scene.buildIndex;
    }

    public void LoadLevel(int Level)
    {
        SceneManager.LoadScene(Level);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextLevel() 
    {
        if (_currentScene + 1 <= 20)
        {
            if(_currentScene >= _levelsComplete)
            {
                _levelsComplete++;
                PlayerPrefs.SetInt("LevelsComplete", _levelsComplete);
            }
            
            SceneManager.LoadScene(_currentScene + 1);
        }
        else SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void RePauseeGame()
    {
        Time.timeScale = 1f;
    }
}
