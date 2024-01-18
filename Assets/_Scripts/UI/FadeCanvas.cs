using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeCanvas : MonoBehaviour
{
    public static FadeCanvas Instance;

    [SerializeField] private CanvasGroup cGroup;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Image loadingBar;
    [SerializeField] private float changevalue;
    [SerializeField] private float waitTime;
    [SerializeField] private bool fadeStarted = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FaderLoadString(string levelName)
    {
        StartCoroutine(FadeOutString(levelName));
    }

    public void FaderLoadInt(int levelIndex)
    {
        StartCoroutine(FadeOutInt(levelIndex));
    }

    private IEnumerator FadeIn()
    {
        loadingScreen.SetActive(false);
        fadeStarted = false;

        while(cGroup.alpha > 0)
        {
            if (fadeStarted == true)
            {
                yield break;
            }  
            cGroup.alpha -= changevalue;    
            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator FadeOutString(string levelName)
    {
        if (fadeStarted)
            yield break;

        fadeStarted = true;

        while (cGroup.alpha < 1)
        {
            cGroup.alpha += changevalue;
            yield return new WaitForSeconds(waitTime);
        }

        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName);
        ao.allowSceneActivation = false;
        loadingScreen.SetActive(true);
        loadingBar.fillAmount = 0;

        while(ao.isDone == false)
        {
            loadingBar.fillAmount = ao.progress / .9f;

            if(ao.progress == 0.9f)
            {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeOutInt(int levelIndex)
    {
        if (fadeStarted)
            yield break;

        fadeStarted = true;

        while (cGroup.alpha < 1)
        {
            cGroup.alpha += changevalue;
            yield return new WaitForSeconds(waitTime);
        }

        AsyncOperation ao = SceneManager.LoadSceneAsync(levelIndex);
        ao.allowSceneActivation = false;
        loadingScreen.SetActive(true);
        loadingBar.fillAmount = 0;

        while (ao.isDone == false)
        {
            loadingBar.fillAmount = ao.progress / .9f;

            if (ao.progress == 0.9f)
            {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }
        StartCoroutine(FadeIn());
    }
}
