using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingTabs : MonoBehaviour
{
    [SerializeField] private DatingMenu _datMenu;

    [Header("Tabs")]
    [SerializeField] private GameObject _nowTab;
    [SerializeField] private GameObject _futureTab;

    [Header("BackButtons")]
    [SerializeField] private GameObject _pastBack;
    [SerializeField] private GameObject _nowBack, _futureBack;

    public void CheckSelected(string str)
    {
        if (PlayerPrefs.HasKey(str))
        {
            ForwardMove();
        }
    }

    public void ForwardMove()
    {
        _futureTab.SetActive(true);
        _futureBack.SetActive(true);
        _nowBack.SetActive(false);
        _futureTab.GetComponent<Animation>().Play("LeftMove");

        _datMenu.ChandeNavigationBar(true);
    }

    public void BackMove()
    {
        _pastBack.SetActive(true);
        _nowBack.SetActive(false);
        _nowTab.GetComponent<Animation>().Play("RightMove");

        _datMenu.ChandeNavigationBar(false);
    }
}
