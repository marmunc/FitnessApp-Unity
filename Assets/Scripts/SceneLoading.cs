using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    [Header("Загружаемая сцена")]
    [SerializeField] private int _sceneID;

    [Header("Остальные объекты")]
    [SerializeField] private Image _loadingImg;
    [SerializeField] private Text _progressText;

    void Start()
    {
        StartCoroutine(AsyncLoad());
    }

    IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneID);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            _loadingImg.fillAmount = progress;
            _progressText.text = string.Format("{0:0}%", progress * 100);
            yield return null;
        }
    }
}
