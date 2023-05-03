using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SceneReloader : MonoBehaviour
{
    [SerializeField] private int _sceneIndex;
    [SerializeField] private Button _reloadButton;
    [SerializeField] private Button _retryButton;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _reloadButton.onClick.AddListener(ReloadScene);
        _retryButton.onClick.AddListener(ReloadScene);
        _nextButton.onClick.AddListener(LoadNextScene);
        _exitButton.onClick.AddListener(Exit);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(_sceneIndex);
    }

    private void LoadNextScene()
    {
        // 
        if (_sceneIndex >= 8)
            _sceneIndex = 0;

        UserData.SaveLevel(_sceneIndex + 1);
        Debug.Log(UserData.GetLevel());
        SceneManager.LoadScene(UserData.GetLevel());
    }

    private void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
