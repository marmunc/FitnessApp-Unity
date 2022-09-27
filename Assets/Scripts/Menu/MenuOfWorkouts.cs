using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuOfWorkouts : MonoBehaviour
{
    private AnimationManager _animManager;
    private int _dayProgress;

    private int _numberWorkout;

    [SerializeField] private GameObject[] _workouts;
    [SerializeField] private GameObject[] _dayExercises;

    [SerializeField] private GameObject[] _standartNameWorkouts;
    [SerializeField] private GameObject[] _nameWithProgress;
    [SerializeField] private Image[] _progressBar1;
    [SerializeField] private Text[] _progressText1;
    [SerializeField] private Image[] _progressBar2;
    [SerializeField] private Text[] _progressText2;

    [SerializeField] private GameObject[] _cubesFullBody;
    [SerializeField] private GameObject[] _cubesPress;
    [SerializeField] private GameObject[] _cubesLegs;
    [SerializeField] private GameObject[] _cubesHands;
    [SerializeField] private GameObject[] _cubesButtocks;

    [SerializeField] private Text[] _textFullBody;
    [SerializeField] private Text[] _textPress;
    [SerializeField] private Text[] _textLegs;
    [SerializeField] private Text[] _textHands;
    [SerializeField] private Text[] _textButtocks;

    [SerializeField] private Sprite _ordinarySprite, _completedSprite;
    private Color _green = new Color(0f, 0.8156863f, 0.4235294f, 1f),
                  _grey = new Color(.43f, .44f, .49f, 1f),
                  _white = new Color(1f, 1f, 1f, 1f);

    private void Start()
    {
        _animManager = gameObject.GetComponent<AnimationManager>();
        _dayProgress = _animManager._trainingProgress;
        UpdateProgressInfo();
    }

    public void SelectionOfWorkouts(int num)
    {
        _numberWorkout = num;
        switch (_numberWorkout)
        {
            case 0:
                ProgressDay(0, _cubesFullBody, _textFullBody);
                _animManager.SelectionOfWorkout(0);
                break;
        }
    }

    public void SelectionOfDay(int numDay)
    {
        switch (_numberWorkout)
        {
            case 0:
                if (numDay <= _dayProgress)
                    _animManager.SelectionOfDayExercises(numDay, _dayExercises);
                break;
        }
    }

    private void ProgressDay(int num, GameObject[] cubes, Text[] dayText)
    {
        if (num < _dayProgress)
        {
            cubes[num].GetComponent<Image>().sprite = _completedSprite;
            dayText[num].color = _green;
        }
        else if (num > _dayProgress)
        {
            cubes[num].GetComponent<Image>().sprite = _ordinarySprite;
            dayText[num].color = _grey;
        }
        else
        {
            cubes[num].GetComponent<Image>().sprite = _ordinarySprite;
            dayText[num].color = _white;
        }

        if (num < 29)
        {
            num = num + 1;
            ProgressDay(num, _cubesFullBody, _textFullBody);
        }
    }

    public void CompleteDay(int num)
    {
        switch (_numberWorkout)
        {
            case 0:
                ProgressUpdate(num, _cubesFullBody, _textFullBody);
                break;
        }
        _dayProgress = num + 1;
        PlayerPrefs.SetInt("FullBodyWorkoutProgress", _dayProgress);
        if (num < _dayExercises.Length) 
        {
            ProgressDay(_dayProgress, _cubesFullBody, _textFullBody);
        }
        UpdateProgressInfo();
    }

    private void ProgressUpdate(int dayCompleted, GameObject[] cubes, Text[] dayText)
    {
        cubes[dayCompleted].GetComponent<Image>().sprite = _completedSprite;
        dayText[dayCompleted].color = _green;
    }

    private void UpdateProgressInfo()
    {
        if (_dayProgress > 0)
        {
            _nameWithProgress[0].SetActive(true);
            _standartNameWorkouts[0].SetActive(false);
            _progressBar1[0].fillAmount = (float)_dayProgress / 30f;
            _progressBar2[0].fillAmount = (float)_dayProgress / 30f;
            _progressText1[0].text = _dayProgress.ToString() + " из 30";
            _progressText2[0].text = _dayProgress.ToString() + "/30";
        }
        else
        {
            _standartNameWorkouts[0].SetActive(true);
            _nameWithProgress[0].SetActive(false);
            _progressBar2[0].fillAmount = (float)_dayProgress / 30f;
        }
    }

    public void OnStartButton()
    {
        SelectionOfDay(_dayProgress);
    }
}
