using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private Button _playBtn;
    [SerializeField] private Button _exitBtn;
    [SerializeField] private TMP_Text _levelTxt;
    [SerializeField] private int _maxLevel;

    private void Start()
    {
        _playBtn.onClick.AddListener(Play);
        _exitBtn.onClick.AddListener(Exit);

        _levelTxt.text = $"Level {GetLevel()}";
    }

    private void Play()
    {
        SceneManager.LoadScene(GetLevel());
    }

    private void Exit()
    {
        Application.Quit();
    } 

    [ContextMenu("ResetLevel")]
    private void ResetLevel()
    {
        UserData.SaveLevel(1);
    }

    private int GetLevel()
    {
        int level = (UserData.GetLevel() == 0) ? 1 : UserData.GetLevel();
        Debug.Log(level);
        // During initialization it is necessary to save the level in case it will be equal to zero
        UserData.SaveLevel(level);

        return (level > _maxLevel) ? 1 : level;
    }
}
