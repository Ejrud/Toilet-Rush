using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class VictoryUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _victoryTxt;
    [SerializeField] private GameObject _victoryScreen;
    [SerializeField] private GameObject _nextBtn;

    private void Start()
    {
        _victoryScreen.SetActive(false);
    }

    public void SetWindowVictory(bool success)
    {
        _victoryScreen.gameObject.SetActive(true);

        if (!success)
        {
            _victoryTxt.text = "Failure";
            _nextBtn.SetActive(false);
            return;
        }

        _nextBtn.SetActive(true);
        _victoryTxt.text = "Success";
    }
}
