using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoading : MonoBehaviour
{
    
    public Image _progressBar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsyncLevel());
    }

    // Update is called once per frame
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
