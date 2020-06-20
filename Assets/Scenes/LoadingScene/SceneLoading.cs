using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoading : MonoBehaviour
{
    
    public Image _progressBar;
    void Start()
    {
        StartCoroutine(LoadAsyncLevel());
    }

    IEnumerator LoadAsyncLevel()
    {
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync("Level");
        while (gameLevel.progress < 1)
        {
            _progressBar.fillAmount = gameLevel.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
