using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOfFood : MonoBehaviour
{
    private AnimationManager _animManager;
    private int _dayProgress;

    [SerializeField] private GameObject[] _dayContents;
    [SerializeField] private Transform[] _contents;
    public GameObject[] _dayCompletely;
    public GameObject[] _foodDescription;

    [SerializeField] private GameObject[] _food;
    //[SerializeField] private GameObject[] _foodDescription;
    [SerializeField] private GameObject _description;

    [SerializeField] private GameObject _finishBtn;
    private GameObject _finish;

    //Здесь отображение дней в прогрессе
    [SerializeField] private GameObject[] _rectangleObj;
    [SerializeField] private Sprite _selectedSprite;
    [SerializeField] private Sprite _completedSprite;
    [SerializeField] private GameObject[] _cubeObj;
    [SerializeField] private GameObject[] _additionallyText;
    [SerializeField] private Text[] _dayText;
    private Color _green = new Color(0f, 0.8156863f, 0.4235294f, 1f),
                  _grey = new Color(1f, 1f, 1f, 0.23f),
                  _black = new Color(0f, 0f, 0f, 1f);

    private void Start()
    {
        _animManager = gameObject.GetComponent<AnimationManager>();
        _dayProgress = _animManager._foodProgress;

        CreateDays(0);
        if (_dayProgress < 6)
            SelectDay(_dayProgress);
    }

    public void CreateDays(int dayEl)
    {
        string day = PlayerPrefs.GetString("day" + (dayEl + 1).ToString());
        string[] numbers = day.Split(' ');

        for (int i = 0; i < numbers.Length; i++)
        {
            Instantiate(_food[int.Parse(numbers[i])], _contents[dayEl].position, Quaternion.identity).transform.SetParent(_contents[dayEl], false);
            //Instantiate(_foodDescription[int.Parse(numbers[i])], _contents[dayEl].position, Quaternion.identity).transform.SetParent(_contents[dayEl], false);
        }

        //Instantiate(_finishBtn, _contents[num].position, Quaternion.identity).transform.SetParent(_contents[num], false);

        ProgressDay(dayEl);

        if (dayEl == _dayProgress) 
        {
            _finish = Instantiate(_finishBtn, _contents[dayEl].position, Quaternion.identity);
            _finish.GetComponent<FinishButton>().NumberButton(dayEl);
            _finish.transform.SetParent(_contents[dayEl], false);
        }

        if (dayEl < 6)
        {
            dayEl = dayEl + 1;
            CreateDays(dayEl);
        }
    }

    public void SelectDay(int dayEl)
    {
        _dayContents[dayEl].SetActive(true);
        for (int i = 0; i < _dayContents.Length; i++)
        {
            if (i != dayEl)
                _dayContents[i].SetActive(false);
        }

        ProgressDay(dayEl);
    }

    private void ProgressDay(int num)
    {
        if (num < _dayProgress)
        {
            _dayCompletely[num].SetActive(true);

            _rectangleObj[num].SetActive(true);
            _rectangleObj[num].GetComponent<Image>().sprite = _completedSprite;
            _cubeObj[num].SetActive(false);
            _additionallyText[num].SetActive(true);
            _dayText[num].color = _green;
        }
        else if (num > _dayProgress)
        {
            _rectangleObj[num].SetActive(false);
            _cubeObj[num].SetActive(true);
            _additionallyText[num].SetActive(false);
            _dayText[num].color = _grey;
        }
        else if (num == _dayProgress)
        {
            _rectangleObj[num].SetActive(true);
            _rectangleObj[num].GetComponent<Image>().sprite = _selectedSprite;
            _cubeObj[num].SetActive(false);
            _additionallyText[num].SetActive(false);
            _dayText[num].color = _black;
        }
    }

    public void CompleteDay(int num)
    {
        ProgressUpdate(num);

        _dayProgress = num + 1;
        PlayerPrefs.SetInt("NutritionalProgress", _dayProgress);
        if (num < 6)
        {
            ProgressDay(_dayProgress);
        }
    }

    private void ProgressUpdate(int dayCompleted)
    {
        _dayCompletely[dayCompleted].SetActive(true);

        _rectangleObj[dayCompleted].SetActive(true);
        _rectangleObj[dayCompleted].GetComponent<Image>().sprite = _completedSprite;
        _cubeObj[dayCompleted].SetActive(false);
        _additionallyText[dayCompleted].SetActive(true);
        _dayText[dayCompleted].color = _green;

        if (dayCompleted < 6)
        {
            _finish = Instantiate(_finishBtn, _contents[dayCompleted + 1].position, Quaternion.identity);
            _finish.GetComponent<FinishButton>().NumberButton(dayCompleted + 1);
            _finish.transform.SetParent(_contents[dayCompleted + 1], false);
        }
    }
}
