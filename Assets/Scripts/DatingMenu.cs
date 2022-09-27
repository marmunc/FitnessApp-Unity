using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatingMenu : DataBase
{
    private float r = 1, g = 1, b = 1, a = 1;
    private float r1 = 0, g1 = 0.8156863f, b1 = 0.4235294f, a1 = 1;

    [Header("Buttons")]
    [SerializeField] private string[] _selectedInfo;
    [SerializeField] private Image[] _standartImg, _productImg;
    [SerializeField] private Text[] _selectedText, _selectedProductText;
    [SerializeField] private Sprite[] _standartSprite, _selectedSprite;

    [Header("Text")]
    [SerializeField] private InputField[] _inputFields;

    private float DCI;

    [Header("Navigation")]
    [SerializeField] private Image _navigationBar;
    private float _fill = 0, _newFill = 0.17f;
    private bool _increas;

    [Header("ProductExclusion")]
    [SerializeField] private int _countExclusion;
    private bool[] _exclusion;

    [SerializeField] private int[] _allFood;
    [SerializeField] private float[] _calories;

    [SerializeField] private int[] _lactose;
    [SerializeField] private int[] _fish;
    [SerializeField] private int[] _pork;
    [SerializeField] private int[] _beef;

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        _exclusion = new bool[_countExclusion];
        _increas = true;
    }

    private void Update()
    {
        if (_increas) 
        {
            if (_newFill > _fill)
            {
                _fill += Time.deltaTime;
                _navigationBar.fillAmount = _fill;
            }
            else
            {
                _increas = false;
            }
        }
        else
        {
            if (_newFill < _fill)
            {
                _fill -= Time.deltaTime;
                _navigationBar.fillAmount = _fill;
            }
        }
    }

    public void SaveAim(int num)
    {
        SaveData("Aim", _selectedInfo[num], 0, 0);
        for (int i = 0; i < 3; i++)
        {
            if (i == num)
            {
                _standartImg[i].sprite = _selectedSprite[i];
                _selectedText[i].color = new Color(r1, g1, b1, a1);
            }
            else
            {
                _standartImg[i].sprite = _standartSprite[i];
                _selectedText[i].color = new Color(r, g, b, a);
            }
        }
    }

    public void SaveGender(int num)
    {
        SaveData("Gender", _selectedInfo[num], 0, 0);
        for (int i = 3; i < 5; i++)
        {
            if (i == num)
            {
                _standartImg[i].sprite = _selectedSprite[3];
                _selectedText[i].color = new Color(r1, g1, b1, a1);
            }
            else
            {
                _standartImg[i].sprite = _standartSprite[3];
                _selectedText[i].color = new Color(r, g, b, a);
            }
        }
    }

    public void SaveTextInfo(string str)
    {
        switch (str)
        {
            case "Years":
                if (_inputFields[0].text != "")
                {
                    SaveData(str, "0", int.Parse(_inputFields[0].text), 0);
                }
                break;
            case "Weight":
                if (_inputFields[1].text != "")
                {
                    SaveData(str, "0", 0, float.Parse(_inputFields[1].text));
                }
                break;
            case "Growth":
                if (_inputFields[2].text != "")
                {
                    SaveData(str, "0", 0, float.Parse(_inputFields[2].text));
                }
                break;
        }
    }

    public void CalorieCalculation()
    {
        if (PlayerPrefs.GetString("Gender") == "Man")
        {
            DCI = (9.99f * PlayerPrefs.GetFloat("Weight") + 6.25f * PlayerPrefs.GetFloat("Growth") - 4.92f * PlayerPrefs.GetFloat("Years") + 5) * 1.2f;
        }
        else
        {
            DCI = (9.99f * PlayerPrefs.GetFloat("Weight") + 6.25f * PlayerPrefs.GetFloat("Growth") - 4.92f * PlayerPrefs.GetFloat("Years") - 161) * 1.2f;
        }
    }

    public void ChandeNavigationBar(bool addition)
    {
        if (addition)
        {
            _newFill += 0.17f;
            _increas = true;
        }
        else
        {
            _newFill -= 0.17f;
            _increas = false;
        }
    }

    public void ProductExclusion(int num)
    {
        if (!_exclusion[num])
        {
            _exclusion[num] = true;
            _productImg[num].sprite = _selectedSprite[3];
            _selectedProductText[num].color = new Color(r1, g1, b1, a1);
        }
        else
        {
            _exclusion[num] = false;
            _productImg[num].sprite = _standartSprite[3];
            _selectedProductText[num].color = new Color(r, g, b, a);
        }
    }

    public void SendFoodMas()
    {
        /*int[] mas = new int[_allFood.Length];
        mas = _allFood;*/

        if (_exclusion[0])
        {
            for (int i = 0; i < _lactose.Length; i++)
            {
                _allFood[_lactose[i]] = 0;
            }
        }
        if (_exclusion[1])
        {
            for (int i = 0; i < _fish.Length; i++)
            {
                _allFood[_fish[i]] = 0;
            }
        }
        if (_exclusion[2])
        {
            for (int i = 0; i < _pork.Length; i++)
            {
                _allFood[_pork[i]] = 0;
            }
        }
        if (_exclusion[3])
        {
            for (int i = 0; i < _beef.Length; i++)
            {
                _allFood[_beef[i]] = 0;
            }
        }

        /*for (int i = 0; i < _allFood.Length; i++)
        {
            print(_allFood[i]);
        }*/

        CreateDayes(_allFood, _calories, DCI);
    }
}
