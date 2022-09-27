using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animation[] animations;
    public int _foodProgress, _trainingProgress;

    [SerializeField] private GameObject _diet;
    [SerializeField] private GameObject _description;
    [SerializeField] private GameObject _workout;
    [SerializeField] private GameObject _exercises;

    private GameObject[] _foodDes;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("NutritionalProgress"))
            _foodProgress = PlayerPrefs.GetInt("NutritionalProgress");
        else
            _foodProgress = 0;

        if (PlayerPrefs.HasKey("FullBodyWorkoutProgress"))
            _trainingProgress = PlayerPrefs.GetInt("FullBodyWorkoutProgress");
        else
            _trainingProgress = 0;
    }

    private void Start()
    {
        animations = new Animation[4];
        animations[0] = _diet.GetComponent<Animation>();
        animations[1] = _description.GetComponent<Animation>();
        animations[2] = _workout.GetComponent<Animation>();
        animations[3] = _exercises.GetComponent<Animation>();

        _foodDes = gameObject.GetComponent<MenuOfFood>()._foodDescription;
    }

    //Выбор дня в диете
    public void SelectionOfDiet()
    {
        _diet.SetActive(true);
        animations[0].Play("LeftMove");
    }

    //Выбор описания в еде
    public void SelectionOfFoodDescription(int num)
    {
        _description.SetActive(true);
        for (int i = 0; i < _foodDes.Length; i++)
        {
            if (i == num) _foodDes[i].SetActive(true);
            else _foodDes[i].SetActive(false);
        }
        animations[1].Play("LeftMove");
    }

    //Выбор тренеровки
    public void SelectionOfWorkout(int num)
    {
        _workout.SetActive(true);
        /*for (int i = 0; i < workouts.Length; i++)
        {
            if (i == num) workouts[i].SetActive(true);
            else workouts[i].SetActive(false);
        }*/
        animations[2].Play("LeftMove");
    }

    //Выбор дня внутри тренировки
    public void SelectionOfDayExercises(int num, GameObject[] dayExercise)
    {
        _exercises.SetActive(true);
        for (int i = 0; i < dayExercise.Length; i++)
        {
            if (i == num) dayExercise[i].SetActive(true);
            else dayExercise[i].SetActive(false);
        }
        animations[3].Play("LeftMove");
    }

    public void Back(int i)
    {
        animations[i].Play("RightMove");
    }
}
