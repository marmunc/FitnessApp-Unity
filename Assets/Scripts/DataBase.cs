using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataBase : MonoBehaviour
{
    public GameObject _loading;

    public int _breakfastLen, _lunchLen, _dinnerLen;
    private string _file;
    private float _calInside = 0, _cal;

    private void Start()
    {
        
    }

    protected void SaveData(string name, string TextInfo, int IntInfo, float FloatInfo)
    {
        switch (name)
        {
            case "Aim":
                PlayerPrefs.SetString(name, TextInfo);
                break;
            case "Gender":
                PlayerPrefs.SetString(name, TextInfo);
                break;
            case "Years":
                PlayerPrefs.SetInt(name, IntInfo);
                break;
            case "Weight":
                PlayerPrefs.SetFloat(name, FloatInfo);
                break;
            case "Growth":
                PlayerPrefs.SetFloat(name, FloatInfo);
                break;
        }
    }

    protected void CreateDayes(int[] mas, float[] cal, float dci)
    {
        for (int j = 0; j < mas.Length; j++)
        {
            if (mas[j] != 0)
            {
                mas[j] = 1;
                
            }
        }

        for (int i = 0; i < 7; i++)
        {
            _calInside = 0;
            _file = "0";

            for (int b = 3; b < _breakfastLen; b++)
            {
                if (mas[b] == 1)
                {
                    _calInside += cal[b];
                    if (_calInside <= dci * 0.2f)
                    {
                        _cal += cal[b];
                        mas[b] += 1;
                        _file += " " + b.ToString();
                    }
                    else
                    {
                        _calInside -= cal[b];
                    }
                }
                else if (mas[b] == 2)
                {
                    mas[b] += 1;
                }
                else if (mas[b] == 3)
                {
                    mas[b] = 1;
                }
            }

            _calInside = 0;
            _file += " 1";

            for (int l = _breakfastLen; l < _lunchLen; l++)
            {
                if (mas[l] == 1)
                {
                    _calInside += cal[l];
                    if (_calInside <= dci * 0.5f)
                    {
                        _cal += cal[l];
                        mas[l] += 1;
                        _file += " " + l.ToString();
                    }
                    else
                    {
                        _calInside -= cal[l];
                    }
                }
                else if (mas[l] == 2)
                {
                    mas[l] += 1;
                }
                else if (mas[l] == 3)
                {
                    mas[l] = 1;
                }
            }

            _calInside = 0;
            _file += " 2";

            for (int d = _lunchLen; d < _dinnerLen; d++)
            {
                if (mas[d] == 1)
                {
                    _calInside += cal[d];
                    if (_calInside <= dci * 0.3f)
                    {
                        _cal += cal[d];
                        mas[d] += 1;
                        _file += " " + d.ToString();
                    }
                    else
                    {
                        _calInside -= cal[d];
                    }
                }
                else if (mas[d] == 2)
                {
                    mas[d] += 1;
                }
                else if (mas[d] == 3)
                {
                    mas[d] = 1;
                }
            }

            PlayerPrefs.SetString("day" + (i + 1).ToString(), _file);
            print("day" + (i + 1).ToString() + " " + _file);
        }

        _loading.SetActive(true);
    }
}
