using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSelection : MonoBehaviour
{
    [SerializeField] private float _countTabs;

    [SerializeField] private Sprite[] _selectedIcons;
    [SerializeField] private Sprite[] _standartIcons;

    [SerializeField] private Image[] _icons;
    [SerializeField] private GameObject[] _tabs;

    [SerializeField] private GameObject _unselectedWorkout;

    [SerializeField] private Vector2[] _bgBtnPosition;
    [SerializeField] private RectTransform _bgBtn;

    [SerializeField] private Text text;

    private void Start()
    {
        SelectTrainingMenu();
    }

    public void SelectTrainingMenu()
    {
        text.text = "План";
        for (int i = 0; i < _countTabs; i++)
        {
            if (i == 1)
            {
                _tabs[i].SetActive(true);
                _icons[i].sprite = _selectedIcons[i];
                _bgBtn.localPosition = _bgBtnPosition[i];
            }
            else
            {
                _tabs[i].SetActive(false);
                _icons[i].sprite = _standartIcons[i];
            }
        }
    }

    public void SelectFootMenu()
    {
        text.text = "Питание";
        _unselectedWorkout.SetActive(false);
        for (int i = 0; i < _countTabs; i++)
        {
            if (i == 0)
            {
                _tabs[i].SetActive(true);
                _icons[i].sprite = _selectedIcons[i];
                _bgBtn.localPosition = _bgBtnPosition[i];
            }
            else
            {
                _tabs[i].SetActive(false);
                _icons[i].sprite = _standartIcons[i];
            }
        }
    }

    public void SelectAccountMenu()
    {
        text.text = "Аккаунт";
        _unselectedWorkout.SetActive(false);
        for (int i = 0; i < _countTabs; i++)
        {
            if (i == 2)
            {
                _tabs[i].SetActive(true);
                _icons[i].sprite = _selectedIcons[i];
                _bgBtn.localPosition = _bgBtnPosition[i];
            }
            else
            {
                _tabs[i].SetActive(false);
                _icons[i].sprite = _standartIcons[i];
            }
        }
    }
}
