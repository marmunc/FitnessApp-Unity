using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOfDescription : MonoBehaviour
{
    private AnimationManager _animManager;

    void Start()
    {
        _animManager = GameObject.Find("Canvas").GetComponent<AnimationManager>();
    }

    public void OutputDescription(int i)
    {
        _animManager.SelectionOfFoodDescription(i);
    }
}
