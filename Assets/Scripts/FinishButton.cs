using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishButton : MonoBehaviour
{
    [SerializeField] private GameObject _button;
    private int _num;

    public void NumberButton(int num)
    {
        _num = num;
    }

    public void OnButtonFood()
    {        
        GameObject.Find("Canvas").GetComponent<MenuOfFood>().CompleteDay(_num);
        _button.SetActive(false);
    }

    public void OnButtonWorkout(int num)
    {
        GameObject.Find("Canvas").GetComponent<MenuOfWorkouts>().CompleteDay(num);
        //_button.SetActive(false);
    }
}
